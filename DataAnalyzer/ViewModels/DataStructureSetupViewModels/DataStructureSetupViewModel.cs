﻿using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using System;
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
        protected readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

        private IImportExportKey selectedDataType = Services.ImportExportKey.Default;
        private string configurationName = string.Empty;
        private string configurationDirectory = string.Empty;
        private string selectedExportType = string.Empty;
        private bool isListening = true;

        public DataStructureSetupViewModel(IDataStructureSetupModel<TDataConfiguration> dataStructureModel)
        {
            this.dataStructureModel = dataStructureModel;
            this.dataStructureModel.PropertyChanged += this.DataStructureModelPropertyChanged;
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;

            this.configurationModel = BaseSingleton<ConfigurationModel>.Instance;
            this.mainModel = BaseSingleton<MainModel>.Instance;
            this.statsModel = BaseSingleton<StatsModel>.Instance;
        }

        public IDataStructureSetupViewModel Default => new NotSupportedSetupViewModel(new());

        public bool IsDefault => this is NotSupportedSetupViewModel;

        public IDataConfiguration DataConfiguration => this.dataStructureModel.DataConfiguration;

        public IImportExportKey SelectedDataType
        {
            get => this.selectedDataType;
            set
            {
                this.NotifyPropertyChangedThen(ref this.selectedDataType, value, () =>
                {
                    this.configurationModel.ImportExportKey = value;
                    // TODO --> may need to make this more structured (data type may not be necessary)
                    this.mainModel.LoadedDataStructure.DataType = value.Name;
                });

            }
        }

        public string ConfigurationName
        {
            get => this.configurationName;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationName, value);

                this.configurationModel.ExecutiveConfigurationName = value;
                this.mainModel.LoadedDataStructure.StructureName = value;

                // The data structure model may not be initialized yet during import/export type switching
                if (this.dataStructureModel.DataConfiguration != null)
                {
                    this.dataStructureModel.DataConfiguration.Name = value;
                }
            }
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                this.configurationModel.ExecutiveConfigurationDirectory = value;

                // TODO --> validate this is the right thing to set in the model
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

        public abstract void Initialize();

        public abstract void ClearConfiguration();

        public abstract bool IsValidSetup(out string reason);

        public abstract void ApplyConfiguration();

        public abstract void SaveConfiguration();

        public abstract void LoadViewModelFromConfiguration();

        public abstract string GetDisplayStringName();

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
                    case nameof(this.configurationModel.ImportExportKey):
                        this.SelectedDataType = this.configurationModel.ImportExportKey;
                        break;
                    case nameof(this.configurationModel.SelectedExportType):
                        this.SelectedExportType = Enum.GetName(typeof(ExportType), this.configurationModel.SelectedExportType);
                        break;
                }
            }
        }

        private void MainModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //switch (e.propertyName)
            //{
            //    case nameof(this.mainModel.)
            //}
        }
    }
}
