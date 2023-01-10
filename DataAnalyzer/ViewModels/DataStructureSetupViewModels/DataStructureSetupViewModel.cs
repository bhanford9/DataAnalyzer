using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal abstract class DataStructureSetupViewModel<TDataConfiguration> : BasePropertyChanged, IDataStructureSetupViewModel
        where TDataConfiguration : IDataConfiguration, new()
    {
        // TODO --> if this isn't used here, it can be removed
        private readonly IDataStructureSetupModel<TDataConfiguration> dataStructureModel;

        protected readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        protected readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        private string selectedDataType = string.Empty;
        private string configurationName = string.Empty;
        private string configurationDirectory = string.Empty;
        private string selectedExportType = string.Empty;
        private bool isListening = true;

        public DataStructureSetupViewModel(
            ObservableCollection<string> dataTypes,
            IDataStructureSetupModel<TDataConfiguration> dataStructureModel)
        {
            this.dataStructureModel = dataStructureModel;
            this.DataTypes = dataTypes;
            this.dataStructureModel.PropertyChanged += this.DataStructureModelPropertyChanged;
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public ObservableCollection<string> DataTypes { get; }

        public IDataConfiguration DataConfiguration => this.dataStructureModel.DataConfiguration;

        public string SelectedDataType
        {
            get => this.selectedDataType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedDataType, value);
                this.configurationModel.SelectedDataType = Enum.Parse<StatType>(value);
                this.mainModel.LoadedDataStructure.DataType = value;
            }
        }

        public string ConfigurationName
        {
            get => this.configurationName;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationName, value);

                // TODO --> make sure there is good rationale for having 3 different locations house this value
                this.configurationModel.ConfigurationName = value;
                this.dataStructureModel.DataConfiguration.Name = value;
                this.mainModel.LoadedDataStructure.StructureName = value;
            }
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                this.configurationModel.ConfigurationDirectory = value;
                this.mainModel.LoadedDataStructure.DirectoryPath = value;
            }
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set
            {
                string inputExportName = this.mainModel.LoadedInputFiles.DataType + "_" + value;
                this.ConfigurationDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                    $"\\DataAnalyzerConfigs\\{value}\\{inputExportName}\\"; // TODO --> put into constant

                this.configurationModel.SelectedExportType = Enum.Parse<ExportType>(value);
                this.mainModel.LoadedDataStructure.ExportType = value;

                // This will set the Executive Type for the app to notify to load in appropriate view models
                if (!this.mainModel.ApplyInputExportTypes())
                {
                    this.ConfigurationDirectory = "NO SUPPORTED EXECUTIVE";
                }

                this.NotifyPropertyChanged(ref this.selectedExportType, value);
                // TODO --> make sure input/scraper selection goes through this same logic
            }
        }

        public void StartListeners() => this.isListening = true;

        public void StopListeners() => this.isListening = false;

        public void CreateNewDataConfiguration() => this.dataStructureModel.CreateNewDataConfiguration();

        public void LoadConfiguration(string configName) => this.dataStructureModel.LoadConfiguration(configName);

        public abstract void ClearConfiguration();

        public abstract bool CanSave(out string reason);

        public abstract void SaveConfiguration();

        public abstract void LoadViewModelFromConfiguration();

        private void DataStructureModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.isListening)
            {
                switch (e.PropertyName)
                {
                    case nameof(this.dataStructureModel.DataConfiguration):
                        this.LoadViewModelFromConfiguration();
                        break;
                }
            }
        }

        protected virtual void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.isListening)
            {
                switch (e.PropertyName)
                {
                    case nameof(this.configurationModel.SelectedDataType):
                        this.SelectedDataType = Enum.GetName(typeof(StatType), this.configurationModel.SelectedDataType);
                        break;
                    case nameof(this.configurationModel.SelectedExportType):
                        this.SelectedExportType = Enum.GetName(typeof(ExportType), this.configurationModel.SelectedExportType);
                        break;
                }
            }
        }
    }
}
