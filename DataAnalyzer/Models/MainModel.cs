using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.Enums.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataScraper.DataScrapers.ScraperFlavors;
using DataAnalyzer.Models.Utilities;

namespace DataAnalyzer.Models
{
    internal class MainModel : BasePropertyChanged
    {
        private IImportType importType;
        private IScraperCategory scraperCategory;
        private IScraperFlavor scraperFlavor;

        private LoadedDataContent loadedDataContent = new();
        private LoadedDataStructure loadedDataStructure = new();
        private LoadedInputFiles loadedInputFiles = new();
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        //private IReadOnlyDictionary<InputExportKey, ExecutiveType> executiveMap;
        ExecutiveLibrary executiveLibrary = new();

        public MainModel()
        {
            loadedInputFiles.PropertyChanged += this.LoadedInputFilesPropertyChanged;
        }

        public LoadedDataContent LoadedDataContent
        {
            get => this.loadedDataContent;
            set => this.NotifyPropertyChanged(ref this.loadedDataContent, value);
        }

        public LoadedDataStructure LoadedDataStructure
        {
            get => this.loadedDataStructure;
            set => this.NotifyPropertyChanged(ref this.loadedDataStructure, value);
        }

        public LoadedInputFiles LoadedInputFiles
        {
            get => this.loadedInputFiles;
            set => this.NotifyPropertyChanged(ref this.loadedInputFiles, value);
        }

        public IImportType ImportType
        {
            get => this.importType;
            set => this.NotifyPropertyChanged(ref this.importType, value);
        }

        public IScraperCategory ScraperCategory
        {
            get => this.scraperCategory;
            set => this.NotifyPropertyChanged(ref this.scraperCategory, value);
        }

        public IScraperFlavor ScraperFlavor
        {
            get => this.scraperFlavor;
            set => this.NotifyPropertyChanged(ref this.scraperFlavor, value);
        }

        public ExecutiveType ExecutiveType { get; private set; }

        //public ScraperCategory ScraperType => Enum.Parse<ScraperCategory>(this.LoadedInputFiles.DataType);

        public void NotifyScraperTypeChange()
        {
            try
            {
                //this.configurationModel.SelectedDataType = this.ScraperType switch
                //{
                //    ScraperCategory.Custom => StatType.Queryable,
                //    ScraperCategory.CsvNames => StatType.CsvNames,
                //    _ => StatType.NotApplicable,
                //};

                //this.NotifyPropertyChanged(nameof(this.ScraperType));
            }
            catch { }
        }

        public bool ApplyInputExportTypes()
        {            
            this.ExecutiveType = this.executiveLibrary.GetExecutiveType(
                this.importType,
                this.ScraperCategory,
                this.scraperFlavor,
                Enum.Parse<ExportType>(this.LoadedDataStructure.ExportType));

            this.NotifyPropertyChanged(nameof(this.ExecutiveType));

            return this.ExecutiveType != ExecutiveType.NotSupported;
        }

        private void LoadedInputFilesPropertyChanged(object sender, PropertyChangedEventArgs e) => this.NotifyScraperTypeChange();
    }
}
