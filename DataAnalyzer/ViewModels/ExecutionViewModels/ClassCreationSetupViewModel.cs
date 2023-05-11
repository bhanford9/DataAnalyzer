using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using SerializationModels = DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

namespace DataAnalyzer.ViewModels.ExecutionViewModels;

internal class ClassCreationSetupViewModel : BasePropertyChanged, IClassCreationSetupViewModel
{
    private readonly IStatsModel statsModel;
    private readonly IStructureExecutiveCommissioner executiveCommissioner;
    private readonly IClassCreationSetupModel setupModel;

    private string selectedConfigDirectory = string.Empty;
    private string configName = string.Empty;
    private string classPreviewText = string.Empty;
    private bool isPreviewing = false;

    private readonly BaseCommand loadInData;
    private readonly BaseCommand selectConfigDirectory;
    private readonly BaseCommand setAllPropertiesToStrings;
    private readonly BaseCommand autoDetectAllProperties;
    private readonly BaseCommand previewClass;
    private readonly BaseCommand exportClass;
    private readonly BaseCommand saveConfiguration;
    private readonly BaseCommand closePreview;
    private readonly BaseCommand copyAllText;

    public ClassCreationSetupViewModel(
        IStatsModel statsModel,
        IStructureExecutiveCommissioner executiveCommissioner,
        IClassCreationSetupModel setupModel)
    {
        this.statsModel = statsModel;
        this.executiveCommissioner = executiveCommissioner;
        this.setupModel = setupModel;

        this.loadInData = new BaseCommand(obj => this.DoLoadInData());
        this.selectConfigDirectory = new BaseCommand(obj => this.DoSelectConfigDirectory());
        this.setAllPropertiesToStrings = new BaseCommand(obj => this.DoSetAllPropertiesToStrings());
        this.autoDetectAllProperties = new BaseCommand(obj => this.DoAutoDetectAllProperties());
        this.previewClass = new BaseCommand(obj => this.DoPreviewClass());
        this.exportClass = new BaseCommand(obj => this.DoExportClass());
        this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());
        this.closePreview = new BaseCommand(obj => this.DoClosePreview());
        this.copyAllText = new BaseCommand(obj => this.DoCopyAllText());

        this.SelectedConfigDirectory = this.setupModel.ClassCreationConfigModel.ConfigurationDirectory;

        this.setupModel.PropertyChanged += SetupModelPropertyChanged;
    }

    public ICommand LoadInData => this.loadInData;
    public ICommand SelectConfigDirectory => this.selectConfigDirectory;
    public ICommand SetAllPropertiesToStrings => this.setAllPropertiesToStrings;
    public ICommand AutoDetectAllProperties => this.autoDetectAllProperties;
    public ICommand PreviewClass => this.previewClass;
    public ICommand ExportClass => this.exportClass;
    public ICommand SaveConfiguration => this.saveConfiguration;
    public ICommand ClosePreview => this.closePreview;
    public ICommand CopyAllText => this.copyAllText;

    public ObservableCollection<IClassSetupBoxViewModel> ClassSetupBoxes { get; } = new();
    public ObservableCollection<IClassCreationConfigListItemViewModel> SavedConfigs { get; } = new();


    public string SelectedConfigDirectory
    {
        get => this.selectedConfigDirectory;
        set
        {
            // TODO --> The display of where the configurations are located is not good enough because
            // the code uses some keywords as sub directories of what is actually displayed

            this.NotifyPropertyChanged(ref this.selectedConfigDirectory, value);
            this.setupModel.ClassCreationConfigModel.ConfigurationDirectory = value;

            this.setupModel.ClassCreationConfigModel.AcquireConfigurations();
            this.UpdateConfigurations();
        }
    }

    public string ConfigName
    {
        get => this.configName;
        set => this.NotifyPropertyChanged(ref this.configName, value);
    }

    public string ClassPreviewText
    {
        get => this.classPreviewText;
        set => this.NotifyPropertyChanged(ref this.classPreviewText, value);
    }

    public bool IsPreviewing
    {
        get => this.isPreviewing;
        set => this.NotifyPropertyChanged(ref this.isPreviewing, value);
    }

    private void DoLoadInData()
    {
        ClassCollectionSetupConfiguration dataConfig =
            this.executiveCommissioner.GetDataConfiguration<ClassCollectionSetupConfiguration>();
        this.statsModel.StructureStats(dataConfig);

        this.ClassSetupBoxes.Clear();

        foreach (IClassSetupConfiguration classConfig in dataConfig.ClassSetupConfigurations)
        {
            this.ClassSetupBoxes.Add(new ClassSetupBoxViewModel()
            {
                ClassName = classConfig.ClassName,
                ClassAccessibility = classConfig.Accessibility,
            });

            foreach (IPropertySetupConfiguration property in classConfig.Properties)
            {
                IClassSetupBoxViewModel classBox = this.ClassSetupBoxes.Last();
                classBox.Properties.Add(new PropertyData()
                {
                    Name = property.Name,
                    SelectedType = property.DataType,
                    SelectedAccessibility = property.Accessibility,
                    IsSimpleProperty = property is ISimplePropertySetupConfiguration,
                });
            }
        }
    }

    private void DoSelectConfigDirectory()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            this.SelectedConfigDirectory = folderBrowserDialog.SelectedPath;
        }
    }

    private void DoSetAllPropertiesToStrings()
    {
        foreach (var prop in this.ClassSetupBoxes)
        {
            //classSetupBox.SelectedType = ClassCreationConstants.STRING_TYPE_DISPLAY;
        }
    }

    private void DoAutoDetectAllProperties()
    {
    }

    private string GetClassString() => this.setupModel.GetClassesString(
        this.ClassSetupBoxes
        .Select(x => new Utilities.ClassData()
        {
            Accessibility = x.ClassAccessibility,
            ClassName = x.ClassName,
            Properties = x.Properties
            .Select(x => new PropertyData()
            {
                Name = x.Name,
                SelectedAccessibility = x.SelectedAccessibility,
                SelectedType = x.SelectedType,
            })
            .ToList(),
        })
        .Cast<Utilities.IClassData>()
        .ToList());

    private void DoPreviewClass()
    {
        this.ClassPreviewText = this.GetClassString();
        this.IsPreviewing = true;
    }

    private void DoExportClass()
    {
        string classString = this.GetClassString();
    }

    private void DoSaveConfiguration()
    {
        this.setupModel.ClassCreationConfigModel.ClassesData.Classes.Clear();

        foreach (var classSetupBox in this.ClassSetupBoxes)
        {
            // TODO this should maybe go through the setup layer instead
            this.setupModel.ClassCreationConfigModel.ClassesData.Classes.Add(new SerializationModels.ClassData()
            {
                ClassName = classSetupBox.ClassName,
                Accessibility = classSetupBox.ClassAccessibility,
                ClassProperties = new ClassProperties()
                {
                    Properties = classSetupBox.Properties
                        .Select(x => new ClassPropertyData()
                        {
                            Accessibility = x.SelectedAccessibility,
                            Name = x.Name,
                            DataType = x.SelectedType,
                        })
                        .Cast<IClassPropertyData>()
                        .ToList(),
                },
            });
        }

        this.setupModel.ClassCreationConfigModel.SaveWorkingConfiguration(this.configName);
        this.executiveCommissioner.SaveConfiguration();

        this.UpdateConfigurations();
    }

    private void DoClosePreview() => this.IsPreviewing = false;

    private void DoCopyAllText() => Clipboard.SetText(this.classPreviewText);

    private void UpdateConfigurations()
    {
        this.SavedConfigs.Clear();
        foreach (var config in this.setupModel.ClassCreationConfigModel.Configurations)
        {
            this.SavedConfigs.Add(new ClassCreationConfigListItemViewModel(this.setupModel.ClassCreationConfigModel)
            {
                IsRemovable = true,
                Value = config
            });
        }
    }

    private void SetupModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(this.setupModel.DataItems):
                this.ClassSetupBoxes.Clear();

                foreach (var dataItem in this.setupModel.DataItems)
                {
                    this.ClassSetupBoxes.Add(new ClassSetupBoxViewModel()
                    {
                        ClassAccessibility = dataItem.Accessibility,
                        ClassName = dataItem.ClassName,
                        Properties = new ObservableCollection<IPropertyData>(dataItem.Properties.ToList()),
                    });
                }
                break;
            case nameof(this.setupModel.ConfigurationName):
                this.ConfigName = this.setupModel.ConfigurationName;
                break;
        }
    }
}
