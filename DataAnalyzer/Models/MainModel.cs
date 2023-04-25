using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services.Enums;
using System;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal class MainModel : BasePropertyChanged, IMainModel
    {
        private ILoadedDataContent loadedDataContent;
        private ILoadedDataStructure loadedDataStructure;
        private ILoadedInputFiles loadedInputFiles;
        private readonly IConfigurationModel configurationModel;

        public MainModel(IConfigurationModel configurationModel)
        {
            this.configurationModel = configurationModel;
            this.loadedDataContent = new LoadedDataContent();
            this.loadedDataStructure = new LoadedDataStructure();
            this.loadedInputFiles = new LoadedInputFiles();

            loadedInputFiles.PropertyChanged += this.LoadedInputFilesPropertyChanged;
        }

        public ILoadedDataContent LoadedDataContent
        {
            get => this.loadedDataContent;
            set => this.NotifyPropertyChanged(ref this.loadedDataContent, value);
        }

        public ILoadedDataStructure LoadedDataStructure
        {
            get => this.loadedDataStructure;
            set => this.NotifyPropertyChanged(ref this.loadedDataStructure, value);
        }

        public ILoadedInputFiles LoadedInputFiles
        {
            get => this.loadedInputFiles;
            set => this.NotifyPropertyChanged(ref this.loadedInputFiles, value);
        }

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
                this.configurationModel.SelectedExportType = exportType;
                this.configurationModel.SaveConfiguration();

                return true;
            }

            return false;
        }

        private void LoadedInputFilesPropertyChanged(object sender, PropertyChangedEventArgs e) => this.NotifyScraperTypeChange();
    }
}
