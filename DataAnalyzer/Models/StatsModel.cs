using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.StatConfigurations.ExcelConfiguration;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.Models
{
    internal class StatsModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ScraperService scraperService = new();
        private HeirarchalStats heirarchalStats;

        private IDataConfiguration activeConfiguration = new NotSupportedDataConfiguration();

        private readonly IReadOnlyDictionary<ExecutiveType, IDataConfiguration> configurationMapping;
        private readonly IReadOnlyDictionary<ExecutiveType, IDataOrganizer> dataOrganizerMapping;

        public StatsModel()
        {
            // TODO --> these should probably use an import/category/flavor/export dictionary instead
            this.configurationMapping = new Dictionary<ExecutiveType, IDataConfiguration>()
            {
                { ExecutiveType.CreateQueryableExcelReport, new ExcelConfiguration() },
                { ExecutiveType.CsvToCSharpClass, new ClassPropertiesConfiguration() },
                { ExecutiveType.NotSupported, new NotSupportedDataConfiguration() },
            };

            this.dataOrganizerMapping = new Dictionary<ExecutiveType, IDataOrganizer>()
            {
                { ExecutiveType.CreateQueryableExcelReport, new ExcelDataOrganizer() },
                { ExecutiveType.CsvToCSharpClass, new CsvDataOrganizer() },
                { ExecutiveType.NotSupported, new NotSupportedDataOrganizer() },
            };

            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public ICollection<IStats> Stats { get; } = new List<IStats>();

        public ObservableCollection<string> StatNames { get; } = new();

        public HeirarchalStats HeirarchalStats
        {
            get => this.heirarchalStats;
            set => this.NotifyPropertyChanged(ref this.heirarchalStats, value);
        }

        public IDataConfiguration ActiveConfiguration
        {
            get => this.activeConfiguration;
            set
            {
                this.configurationModel.DataConfiguration = value;
                this.NotifyPropertyChanged(ref this.activeConfiguration, value);
            }
        }

        public void ClearLoadedStats()
        {
            this.Stats.Clear();

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void LoadStatsFromSource(IDataSource source)
        {
            IImportType type = this.mainModel.ImportType;
            IScraperCategory category = this.mainModel.ScraperCategory;
            IScraperFlavor flavor = this.mainModel.ScraperFlavor;

            this.Stats.Clear();

            this.scraperService.ScrapeFromSource(source, type, category, flavor)
                .ToList()
                .ForEach(this.Stats.Add);

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void StructureStats(AppDataConfig.IDataConfiguration applicationConfiguration)
        {
            this.activeConfiguration.Initialize(this.configurationModel.DataParameterCollection, applicationConfiguration);

            this.HeirarchalStats = this.dataOrganizerMapping[this.mainModel.ExecutiveType].Organize(this.activeConfiguration, this.Stats);

            this.LoadStatNames(this.HeirarchalStats);
        }

        private void LoadStatNames(HeirarchalStats stats)
        {
            if (stats.Children.Count == 0)
            {
                stats.ParameterNames.ToList().ForEach(x => this.StatNames.Add(x));
                this.NotifyPropertyChanged(nameof(this.StatNames));
                return;
            }

            this.LoadStatNames(stats.Children.First());
        }

        private void MainModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ExecutiveType):
                    this.ActiveConfiguration = this.configurationMapping[this.mainModel.ExecutiveType];
                    break;
            }
        }

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ConfigurationFilePath):
                    break;
            }
        }
    }
}
