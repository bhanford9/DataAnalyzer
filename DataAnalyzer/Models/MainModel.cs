using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal class MainModel : BasePropertyChanged
    {
        private LoadedDataContent loadedDataContent = new();
        private LoadedDataStructure loadedDataStructure = new();
        private LoadedInputFiles loadedInputFiles = new();
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        private IReadOnlyDictionary<InputExportKey, ExecutiveType> executiveMap;

        public MainModel()
        {
            executiveMap = new Dictionary<InputExportKey, ExecutiveType>()
            {
                { new InputExportKey(ScraperType.CsvNames, ExportType.CSharpStringProperties), ExecutiveType.CsvToCSharpClass },
                { new InputExportKey(ScraperType.Queryable, ExportType.Excel), ExecutiveType.CreateQueryableExcelReport},
            };

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

        public ExecutiveType ExecutiveType { get; private set; }

        public ScraperType ScraperType => Enum.Parse<ScraperType>(this.LoadedInputFiles.DataType);

        public void NotifyScraperTypeChange()
        {
            try
            {
                this.configurationModel.SelectedDataType = this.ScraperType switch
                {
                    ScraperType.Queryable => StatType.Queryable,
                    ScraperType.CsvNames => StatType.CsvNames,
                    _ => StatType.NotApplicable,
                };

                this.NotifyPropertyChanged(nameof(this.ScraperType));
            }
            catch { }
        }

        public bool ApplyInputExportTypes()
        {
            ScraperType scraperType = Enum.Parse<ScraperType>(this.LoadedInputFiles.DataType);
            ExportType exportType = Enum.Parse<ExportType>(this.LoadedDataStructure.ExportType);
            bool supported = false;

            if (this.executiveMap.TryGetValue(new InputExportKey(scraperType, exportType), out ExecutiveType executiveType))
            {
                this.ExecutiveType = executiveType;
                supported = true;
            }
            else
            {
                this.ExecutiveType = ExecutiveType.NotSupported;
            }

            this.NotifyPropertyChanged(nameof(this.ExecutiveType));
            return supported;
        }

        private void LoadedInputFilesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.NotifyScraperTypeChange();
        }
    }
}
