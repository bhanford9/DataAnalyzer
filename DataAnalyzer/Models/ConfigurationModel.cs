﻿using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System;
using System.IO;

namespace DataAnalyzer.Models
{
    internal class ConfigurationModel : BasePropertyChanged
    {
        private readonly SerializationService serializer = new();

        // TODO --> I feel like these two don't belong here
        private readonly DataParameterLibrary dataParameterLibrary = new();
        private IDataParameterCollection dataParameterCollection = null;

        // These fields are set on page zero and allow the user to have different application configurations
        // This can help compartmentalize if the application grows to be large
        private string configurationDirectory = string.Empty;
        private string configurationName = "MyAppConfig";
        private string configurationFilePath = string.Empty;

        private IImportType importType = null;
        private IScraperCategory category = null;
        private IScraperFlavor flavor = null;
        private ExportType selectedExportType = ExportType.NotApplicable;

        // This refers to where data configurations are stored which is an autogenerated path based on the others, so this is OBE
        private string savedDataFilePath = string.Empty;

        // TODO --> this probably isn't a thing anymore
        private StatType selectedStatType = StatType.NotApplicable;

        public ConfigurationModel()
        {
            this.ConfigurationDirectory = Properties.Settings.Default.LastUsedApplicationRootDirectory;
            this.ConfigurationName = Properties.Settings.Default.LastUsedApplicationConfigurationName;
            this.ApplyFilePath();
            this.LoadConfiguration();

            // TODO --> this should have a save/apply method
            // TODO --> main model should be updating this guy with import/category/flavor/export (the properties don't need to be here)
            // TODO --> make sure to handle partially set types
        }

        // TODO --> not sure stat type is going to be a thing anymore
        public StatType SelectedDataType
        {
            get => this.selectedStatType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedStatType, value);
                this.DataParameterCollection = this.dataParameterLibrary.GetParameters(value);
            }
        }

        public ExportType SelectedExportType
        {
            get => this.selectedExportType;
            set => this.NotifyPropertyChanged(ref this.selectedExportType, value);
        }

        public IImportType ImportType
        {
            get => this.importType;
            set => this.NotifyPropertyChanged(ref this.importType, value);
        }

        public IScraperCategory Category
        {
            get => this.category;
            set => this.NotifyPropertyChanged(ref this.category, value);
        }

        public IScraperFlavor Flavor
        {
            get => this.flavor;
            set => this.NotifyPropertyChanged(ref this.flavor, value);
        }

        // TODO --> should this actually be in this location? Maybe keep it in the stats model instead
        public IDataParameterCollection DataParameterCollection
        {
            get => this.dataParameterCollection;
            set => this.NotifyPropertyChanged(ref this.dataParameterCollection, value);
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);

                Properties.Settings.Default.LastUsedApplicationRootDirectory = value;
                Properties.Settings.Default.Save();
                this.ApplyFilePath();
            }
        }

        public string ConfigurationName
        {
            get => this.configurationName;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationName, value);
                Properties.Settings.Default.LastUsedApplicationConfigurationName = value;
                Properties.Settings.Default.Save();
                this.ApplyFilePath();
            }
        }

        public string ConfigurationFilePath
        {
            get => this.configurationFilePath;
            set => this.NotifyPropertyChanged(ref this.configurationFilePath, value);
        }

        // This refers to where data configurations are stored which is an autogenerated path based on the others, so this is OBE
        public string SavedDataFilePath
        {
            get => this.savedDataFilePath;
            set => this.NotifyPropertyChanged(ref this.savedDataFilePath, value);
        }

        public void ApplyConfiguration(IImportType import, IScraperCategory category, IScraperFlavor flavor)
        {
            this.ImportType = import;
            this.Category = category;
            this.Flavor = flavor;
        }

        public bool HasLoaded { get; private set; } = false;

        public void SaveConfiguration()
        {
            ApplicationConfiguration config = new ApplicationConfiguration()
            {
                SelectedImport = this.importType,
                SelectedCategory = this.category,
                SelectedFlavor = this.flavor,
                SelectedExport = this.selectedExportType,
                DateTime = DateTime.Now,
            };

            serializer.JsonSerializeToFile(config, this.configurationFilePath);
        }

        public bool LoadConfiguration()
        {
            try
            {
                ApplicationConfiguration config = serializer.JsonDeserializeFromFile<ApplicationConfiguration>(this.configurationFilePath);
                this.ImportType = config.SelectedImport;
                this.Category = config.SelectedCategory;
                this.Flavor = config.SelectedFlavor;
                this.SelectedExportType = config.SelectedExport;
                return this.HasLoaded = true;
            }
            catch
            {
                return this.HasLoaded = false;
            }
        }

        private void ApplyFilePath()
        {
            string filePath = Path.Combine(this.configurationDirectory, this.configurationName);

            if (!filePath.EndsWith(".json"))
            {
                filePath += ".json";
            }

            if (File.Exists(filePath))
            {
                this.ConfigurationFilePath = filePath;
            }
        }
    }
}
