using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
    internal class ExcelDataTypesViewModel : BasePropertyChanged
    {
        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;

        private string configurationDirectory = string.Empty;
        private string dataTypeConfigName = string.Empty;

        private readonly BaseCommand browseDirectory;
        private readonly BaseCommand saveDataTypes;

        private readonly IReadOnlyDictionary<Type, Func<ITypeParameter, IDataTypeConfigViewModel>> typeParameterToViewModel
            = new Dictionary<Type, Func<ITypeParameter, IDataTypeConfigViewModel>>
            {
                { typeof(NoTypeParameter), x => new NoParameterDataTypeViewModel(x) },
                { typeof(IntegerTypeParameter), x => new OneParameterDataTypeViewModel<int>(x) },
                { typeof(IntegerIntegerTypeParameter), x => new TwoParameterDataTypeViewModel<int, int>(x) },
                { typeof(IntegerBooleanTypeParameter), x => new TwoParameterDataTypeViewModel<int, bool>(x) },
            };

        private readonly IReadOnlyDictionary<ParameterType, Func<ITypeParameter, IDataTypeConfigViewModel>> parameterTypeToToViewModel
            = new Dictionary<ParameterType, Func<ITypeParameter, IDataTypeConfigViewModel>>
            {
                { ParameterType.None, x => new NoParameterDataTypeViewModel(x) },
                { ParameterType.Integer, x => new OneParameterDataTypeViewModel<int>(x) },
                { ParameterType.IntegerInteger, x => new TwoParameterDataTypeViewModel<int, int>(x) },
                { ParameterType.IntegerBoolean, x => new TwoParameterDataTypeViewModel<int, bool>(x) },
            };

        public ExcelDataTypesViewModel()
        {
            this.browseDirectory = new BaseCommand(obj => this.DoBrowseDirectory());
            this.saveDataTypes = new BaseCommand(obj => this.DoSaveDataTypes());

            this.ConfigurationDirectory = this.excelSetupModel.ExcelConfiguration.ConfigurationDirectory;

            this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
            this.excelSetupModel.ExcelConfiguration.PropertyChanged += this.ExcelConfigurationPropertyChanged;
            this.excelSetupModel.PropertyChanged += ExcelSetupModelPropertyChanged;
            this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;
        }


        public ObservableCollection<ExcelDataTypeListItemViewModel> SavedConfigurations { get; } = new();

        public ObservableCollection<IDataTypeConfigViewModel> ParameterSelections { get; } = new();

        public ICommand BrowseDirectory => this.browseDirectory;
        public ICommand SaveDataTypes => this.saveDataTypes;

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                this.excelSetupModel.ExcelConfiguration.ConfigurationDirectory = value;
            }
        }

        public string DataTypeConfigName
        {
            get => this.dataTypeConfigName;
            set => this.NotifyPropertyChanged(ref this.dataTypeConfigName, value);
        }

        private void DoBrowseDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ApplyConfigurationDirectory(folderBrowserDialog.SelectedPath);
            }
        }

        private void DoSaveDataTypes()
        {
            if (string.IsNullOrEmpty(this.DataTypeConfigName))
            {
                // TODO --> notify name cannot be blank
                return;
            }

            if (this.SavedConfigurations.Any(x => x.Value.Equals(this.DataTypeConfigName)))
            {
                // TODO --> verify overwrite existing configuration
            }

            this.excelSetupModel.ExcelConfiguration.SaveDataTypeConfiguration(
                this.ParameterSelections.Select(x => x.TypeParameter).ToList(),
                this.DataTypeConfigName);
        }

        private void ApplyConfigurationDirectory(string file)
        {
            if (Directory.Exists(file))
            {
                this.ConfigurationDirectory = file;
                List<string> configFiles = Directory.GetFiles(file).ToList();
                this.SavedConfigurations.Clear();

                configFiles.ForEach(configFilePath =>
                {
                    string configFile = Path.GetFileName(configFilePath);
                    string displayText = configFile;
                    while (displayText.Contains('.'))
                    {
                        displayText = Path.GetFileNameWithoutExtension(displayText);
                    }

                    this.SavedConfigurations.Add(new ExcelDataTypeListItemViewModel { Value = displayText, ToolTipText = configFile });
                });
            }
        }

        private void LoadDataTypesFromConfig()
        {
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.statsModel.StatNames):
                    this.ParameterSelections.Clear();

                    foreach (string name in this.statsModel.StatNames)
                    {
                        ITypeParameter typeParameter = this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes?
                          .FirstOrDefault(x => x.DataName.Equals(name));

                        if (typeParameter != default)
                        {
                            this.ParameterSelections.Add(this.typeParameterToViewModel[typeParameter.GetType()](typeParameter));
                        }
                        else
                        {
                            // TODO --> initialize to General Excel Type so the UI isn't in a weird state
                            NoTypeParameter temp = new NoTypeParameter();
                            temp.DataName = name;
                            this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes.Add(temp);
                            this.ParameterSelections.Add(new NoParameterDataTypeViewModel(temp));
                        }
                    }

                    break;
            }
        }

        private void ExcelConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.excelSetupModel.ExcelConfiguration.DataTypeConfigName):
                    this.DataTypeConfigName = this.excelSetupModel.ExcelConfiguration.DataTypeConfigName;
                    break;
                //case nameof(this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes):
                //    this.ParameterSelections.Clear();

                //    this.excelSetupModel.ExcelConfiguration.LoadedParameterTypes.ToList()
                //        .ForEach(typeParameters => this.ParameterSelections.Add(
                //            this.typeParameterToViewModel[typeParameters.GetType()](typeParameters)));
                //    break;
                case nameof(this.excelSetupModel.ExcelConfiguration.DataTypeConfigurationPath):
                    break;
                case nameof(this.excelSetupModel.ExcelConfiguration.SavedConfigurations):
                    this.SavedConfigurations.Clear();
                    this.excelSetupModel.ExcelConfiguration.SavedConfigurations.ToList().ForEach(savedConfig =>
                    {
                        this.SavedConfigurations.Add(new ExcelDataTypeListItemViewModel
                        {
                            IsRemovable = true,
                            Value = savedConfig.FileName,
                            ToolTipText = savedConfig.FilePath
                        });
                    });
                    break;
            }
        }

        private void ExcelSetupModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.excelSetupModel.WorkingParameterTypes):
                    this.ParameterSelections.Clear();

                    this.excelSetupModel.WorkingParameterTypes.ToList()
                        .ForEach(typeParameters => this.ParameterSelections.Add(
                            this.typeParameterToViewModel[typeParameters.GetType()](typeParameters)));
                    break;
            }

            if (e.PropertyName.StartsWith(ExcelSetupModel.DATA_TYPE_UPDATE_KEY))
            {
                string dataName = e.PropertyName[ExcelSetupModel.DATA_TYPE_UPDATE_KEY.Length..];
                for (int i = 0; i < this.ParameterSelections.Count; i++)
                {
                    IDataTypeConfigViewModel viewModel = this.ParameterSelections[i];
                    IDataTypeConfigViewModel proposedChange = parameterTypeToToViewModel[viewModel.TypeParameter.Type](viewModel.TypeParameter);
                    if (viewModel.DataName.Equals(dataName) && !viewModel.Equals(proposedChange))
                    {
                        this.ParameterSelections[i] = proposedChange;
                        break;
                    }
                }
            }
        }

        private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
