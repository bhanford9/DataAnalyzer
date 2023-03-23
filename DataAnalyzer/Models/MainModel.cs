using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using System;
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

        ExecutiveLibrary executiveLibrary = new();

        public MainModel()
        {
            loadedInputFiles.PropertyChanged += this.LoadedInputFilesPropertyChanged;

            if (this.configurationModel.LoadConfiguration())
            {
                this.ImportType = this.configurationModel.ImportType;
                this.ScraperCategory = this.configurationModel.Category;
                this.ScraperFlavor = this.configurationModel.Flavor;

                ExportType exportType = this.configurationModel.SelectedExportType;
                this.ExecutiveType = this.executiveLibrary.GetExecutiveType(
                    this.importType,
                    this.scraperCategory,
                    this.scraperFlavor,
                    exportType);
            }
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
            set
            {
                this.NotifyPropertyChangedThen(ref this.importType, value, () =>
                {
                    this.configurationModel.ImportType = value;
                    this.configurationModel.SaveConfiguration();
                });
            }
        }

        public IScraperCategory ScraperCategory
        {
            get => this.scraperCategory;
            set
            {
                this.NotifyPropertyChangedThen(ref this.scraperCategory, value, () =>
                {
                    this.configurationModel.Category = value;
                    this.configurationModel.SaveConfiguration();
                });
            }
        }

        public IScraperFlavor ScraperFlavor
        {
            get => this.scraperFlavor;
            set
            {
                this.NotifyPropertyChangedThen(ref this.scraperFlavor, value, () =>
                {
                    this.configurationModel.Flavor = value;
                    this.configurationModel.SaveConfiguration();
                });
            }
        }

        // TODO --> moving away from this enum and to using an executive utilities repository
        public ExecutiveType ExecutiveType { get; private set; }

        //public ScraperCategory ScraperType => Enum.Parse<ScraperCategory>(this.LoadedInputFiles.DataType);

        public void NotifyScraperTypeChange()
        {
            try
            {
                //this.configurationModel.SelectedDataType = this.ScraperType switch
                //{
                //    ScraperCategory.Custom => ImportExportKey.Queryable,
                //    ScraperCategory.CsvNames => ImportExportKey.CsvNames,
                //    _ => ImportExportKey.NotApplicable,
                //};

                //this.NotifyPropertyChanged(nameof(this.ScraperType));
            }
            catch { }
        }

        public bool ApplyInputExportTypes()
        {
            ExportType exportType = Enum.Parse<ExportType>(this.LoadedDataStructure.ExportType);

            if (exportType != ExportType.NotApplicable)
            {
                this.ExecutiveType = this.executiveLibrary.GetExecutiveType(
                    this.importType,
                    this.ScraperCategory,
                    this.scraperFlavor,
                    exportType);

                this.configurationModel.SelectedExportType = exportType;
                this.configurationModel.SaveConfiguration();

                this.NotifyPropertyChanged(nameof(this.ExecutiveType));

                return true;
            }

            return false;
        }

        private void LoadedInputFilesPropertyChanged(object sender, PropertyChangedEventArgs e) => this.NotifyScraperTypeChange();
    }
}
