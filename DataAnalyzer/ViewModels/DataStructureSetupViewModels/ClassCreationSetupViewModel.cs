using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.ClassStats;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.CustomDocumentInformationPanel;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class ClassCreationSetupViewModel :
        DataStructureSetupViewModel<ClassSetupConfiguration>,
        IClassCreationSetupViewModel
    {
        private string className = string.Empty;

        // optionally may want to move this into the parentViewModel as the interface
        private readonly IClassCreationSetupModel model;

        private IPropertyBoxViewModel classesBox;

        public ClassCreationSetupViewModel(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            IStatsModel statsModel,
            INotSupportedSetupViewModel defaultViewModel,
            IClassCreationSetupModel model)
            : base(configurationModel, statsModel, mainModel, model)
        {
            this.model = model;
            this.Default = defaultViewModel;
            this.model.PropertyChanged += this.ModelPropertyChanged;
        }

        public ObservableCollection<IPropertyBoxViewModel> ClassPropertiesBoxes { get; set; } = new();

        public string ClassName
        {
            get => this.className;
             // TODO --> set first class box name and first classes entry name
            set => this.NotifyPropertyChanged(ref this.className, value);
        }

        public IPropertyBoxViewModel ClassesBox
        {
            get => this.classesBox;
            set => this.NotifyPropertyChanged(ref this.classesBox, value);
        }

        public override IDataStructureSetupViewModel Default { get; }

        public override bool IsValidSetup(out string reason)
        {
            reason = string.Empty;

            if (string.IsNullOrEmpty(this.ClassName))
            {
                reason = "Class Name cannot be left empty";
                return false;
            }

            return true;
        }

        public override void ClearConfiguration()
        {
            //this.SelectedDataType = ImportExecutionKey.NotApplicable.ToString();
        }

        public override void LoadViewModelFromConfiguration()
        {
            this.ConfigurationName = this.model.DataConfiguration.Name;
            this.ClassName = this.model.DataConfiguration.ClassName;
            this.ClassPropertiesBoxes.Clear();

            this.model.DataConfiguration.Properties.ToList().ForEach(AddPropertyBoxFromAppConfig);
        }

        public override void ApplyConfiguration()
        {
            this.model.CreateNewDataConfiguration();

            this.model.DataConfiguration.Name = this.ConfigurationName;
            this.model.DataConfiguration.ClassName = this.ClassName;

            foreach (IPropertyBoxViewModel propBox in this.ClassPropertiesBoxes)
            {
                this.model.DataConfiguration.Properties.Add(this.ApplyToPropertyConfig(propBox));
            }
        }

        private IClassPropertySetupConfiguration ApplyToPropertyConfig(IPropertyBoxViewModel propBox)
        {
            IClassPropertySetupConfiguration classProp = new ClassPropertySetupConfiguration
            {
                Name = propBox.ContainerName
            };

            propBox.Properties.ToList().ForEach(
                    x => classProp.Properties.Add(x.PropertyType switch
                    {
                        PropertyType.Class => new ClassPropertySetupConfiguration()
                        {
                            Name = x.PropertyName,
                        },
                        PropertyType.Collection => new CollectionPropertySetupConfiguration()
                        {
                            Name = x.PropertyName,
                        },
                        PropertyType.Simple => new SimplePropertySetupConfiguration()
                        {
                            Name = x.PropertyName
                        },
                        _ => throw new ArgumentOutOfRangeException(),
                    }));

            return classProp;
        }

        public override void SaveConfiguration()
        {
            this.ApplyConfiguration();
            this.model.SaveConfiguration();
        }

        public override void Initialize()
        {
            List<ClassStats> classStats = this.statsModel.Stats.OfType<ClassStats>().ToList();
            this.ClassPropertiesBoxes.Clear();

            if (classStats.Any())
            {
                IClassStats stats = classStats[0];

                this.classesBox = new PropertyBoxViewModel()
                {
                    ContainerName = "Classes",
                };

                this.ClassName = stats.Name;
                this.ConfigurationName = stats.Name;

                this.AddClass(stats.Name, stats.Properties);
                this.AddPropertiesAsClasses(stats.Properties);

                this.NotifyPropertyChanged(nameof(this.ClassesBox));
            }
        }

        public override string GetDisplayStringName() => nameof(StructureExecutiveCommissioner.DisplayCsvToClassSetup);

        private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // may not be necessary for this class
        }

        private void AddPropertyBoxFromAppConfig(IPropertySetupConfiguration appConfig)
        {
            if (appConfig is IClassPropertySetupConfiguration classConfig)
            {
                foreach (IPropertySetupConfiguration x in classConfig.Properties)
                {
                    if (this.ClassPropertiesBoxes.All(y => y.ContainerName != classConfig.Name))
                    {
                        this.AddPropertyBoxFromAppConfig(x);
                    }
                }

                IPropertyBoxViewModel newViewModel = GetPropertyBoxFromAppConfig(classConfig);
                if (newViewModel.Properties.Count > 0)
                {
                    this.ClassPropertiesBoxes.Add(newViewModel);
                }
            }
            else if (appConfig is ICollectionPropertySetupConfiguration collectionConfig)
            {
                foreach (IPropertySetupConfiguration x in collectionConfig.Properties)
                {
                    if (this.ClassPropertiesBoxes.All(y => y.ContainerName != collectionConfig.Name))
                    {
                        this.AddPropertyBoxFromAppConfig(x);
                        IPropertyBoxViewModel newViewModel = GetPropertyBoxFromAppConfig(x);
                        if (newViewModel.Properties.Count > 0)
                        {
                            this.ClassPropertiesBoxes.Add(newViewModel);
                        }
                    }
                }
            }
        }

        private IPropertyBoxViewModel GetPropertyBoxFromAppConfig(IPropertySetupConfiguration appConfig) =>
            new PropertyBoxViewModel()
            {
                ContainerName = appConfig.Name,
                Properties = appConfig switch
                {
                    IClassPropertySetupConfiguration classConfig => // TODO --> add 'include' to app config
                        classConfig.Properties
                            .Select(x => this.GetPropertyRow(x.Name, PropertyType.Class, true))
                            .ToList(),
                    ICollectionPropertySetupConfiguration collectionConfig =>
                        collectionConfig.Properties
                            .Select(x => this.GetPropertyRow(x.Name, PropertyType.Collection, true))
                            .ToList(),
                    _ => new List<IStringPropertyRowViewModel>()
                },
            };

        private void AddClass(string className, ICollection<IProperty> properties)
        {
            this.classesBox.Properties.Add(this.GetPropertyRow(
                className,
                PropertyType.Class,
                true // TODO
                ));

            IPropertyBoxViewModel newClassPropertyBox = new PropertyBoxViewModel()
            {
                ContainerName = className,
                Properties = properties
                    .Select(x => this.GetPropertyRow(
                        x.Name,
                        this.GetPropertyType(x),
                        true // TODO
                        ))
                    .ToList()
            };

            this.ClassPropertiesBoxes.Add(newClassPropertyBox);
        }

        private void AddPropertiesAsClasses(ICollection<IProperty> properties)
        {
            foreach (IProperty prop in properties)
            {
                switch (prop)
                {
                    case IClassProperty classProp:
                        if (!this.classesBox.Properties.Any(x => x.SerializedName.Equals(prop.Name)))
                        {
                            this.AddClass(classProp.Name, classProp.Properties);
                            this.AddPropertiesAsClasses(classProp.Properties);
                        }
                        break;
                    case ICollectionProperty collectionProp:
                        this.AddPropertiesAsClasses(collectionProp.Properties);
                        break;
                    default: break;
                }
            }
        }

        private IStringPropertyRowViewModel GetPropertyRow(
            string name,
            PropertyType propType,
            bool include = true) =>
            new StringPropertyRowViewModel()
            {
                Include = include,
                PropertyName = name,
                SerializedName = name,
                PropertyType = propType,
            };

        private PropertyType GetPropertyType(IProperty property) => property switch
        {
            ISimpleProperty => PropertyType.Simple,
            IClassProperty => PropertyType.Class,
            ICollectionProperty => PropertyType.Collection,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
