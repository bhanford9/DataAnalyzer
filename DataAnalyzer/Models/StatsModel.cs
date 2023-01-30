using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataAnalyzer.Common.DataConfigurations;
using DataAnalyzer.Common.DataConfigurations.CsvConfigurations;
using DataAnalyzer.Common.DataConfigurations.ExcelConfiguration;
using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
    internal class StatsModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ScraperService scraperService = new();
        private HeirarchalStats heirarchalStats;

        private IDataConfiguration activeConfiguration;

        private readonly IReadOnlyDictionary<ExecutiveType, IDataConfiguration> configurationMapping;
        private readonly IReadOnlyDictionary<ExecutiveType, IDataOrganizer> dataOrganizerMapping;

        public StatsModel()
        {
            this.configurationMapping = new Dictionary<ExecutiveType, IDataConfiguration>()
            {
                { ExecutiveType.CreateQueryableExcelReport, new ExcelConfiguration() },
                { ExecutiveType.CsvToCSharpClass, new CsvConfiguration() },
                { ExecutiveType.NotSupported, new NotSupportedDataConfiguration() },
            };

            this.dataOrganizerMapping = new Dictionary<ExecutiveType, IDataOrganizer>()
            {
                { ExecutiveType.CreateQueryableExcelReport, new ExcelDataOrganizer() },
                { ExecutiveType.CsvToCSharpClass, new CsvDataOrganizer() },
                { ExecutiveType.NotSupported, new NotSupportedDataOrganizer() },
            };

            mainModel.PropertyChanged += this.MainModelPropertyChanged;
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
            set => this.NotifyPropertyChanged(ref this.activeConfiguration, value);
        }

        public void ClearLoadedStats()
        {
            this.Stats.Clear();

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void LoadStatsForFile(string filePath, IDataConverter converter)
        {
            this.scraperService.ScrapeFromFile(filePath, converter, this.mainModel.ScraperType)
                .ToList()
                .ForEach(this.Stats.Add);

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void StructureStats(ApplicationConfigurations.DataConfigurations.IDataConfiguration applicationConfiguration)
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
    }
}
