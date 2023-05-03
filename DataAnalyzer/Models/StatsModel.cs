using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.Services.ExecutiveUtilities.Executives;
using DataAnalyzer.StatConfigurations;
using DataScraper.DataSources;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.Models
{
    internal class StatsModel : BasePropertyChanged, IStatsModel
    {
        private readonly IConfigurationModel configurationModel;
        private readonly IScraperService scraperService;
        private IHeirarchalStats heirarchalStats;

        private IDataConfiguration activeConfiguration = new NotSupportedDataConfiguration();

        private readonly IExecutiveUtilitiesRepository executiveUtilities;
        
        private readonly IStatAccessorLibrary dataAccessorLibrary;
        private IStatAccessorCollection dataAccessorCollection = null;

        public StatsModel(
            IConfigurationModel configModel,
            IScraperService scraperService,
            IExecutiveUtilitiesRepository executiveUtilities,
            IStatAccessorLibrary dataAccessorLibrary)
        {
            this.configurationModel = configModel;
            this.scraperService = scraperService;
            this.executiveUtilities = executiveUtilities;
            this.dataAccessorLibrary = dataAccessorLibrary;
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public ICollection<IStats> Stats { get; } = new List<IStats>();

        public ObservableCollection<string> StatNames { get; } = new();

        public IHeirarchalStats HeirarchalStats
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

        public IStatAccessorCollection DataAccessorCollection
        {
            get => this.dataAccessorCollection;
            set => this.NotifyPropertyChanged(ref this.dataAccessorCollection, value);
        }

        public void ClearLoadedStats()
        {
            this.Stats.Clear();

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void LoadStatsFromSource(IDataSource source)
        {
            this.Stats.Clear();

            this.scraperService.ScrapeFromSource(source, this.configurationModel.ImportExportKey.ImportKey)
                .ToList()
                .ForEach(this.Stats.Add);

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void StructureStats(AppDataConfig.IDataConfiguration applicationConfiguration)
        {
            this.activeConfiguration.Initialize(
                this.DataAccessorCollection,
                applicationConfiguration);

            this.HeirarchalStats = this.executiveUtilities
                .GetDataOrDefault(this.configurationModel.ImportExportKey)
                .DataOrganizer.Organize(this.activeConfiguration, this.Stats);

            this.LoadStatNames(this.HeirarchalStats);
        }

        private void LoadStatNames(IHeirarchalStats stats)
        {
            if (stats.Children.Count == 0)
            {
                stats.ParameterNames.ToList().ForEach(x => this.StatNames.Add(x));
                this.NotifyPropertyChanged(nameof(this.StatNames));
                return;
            }

            this.LoadStatNames(stats.Children.First());
        }

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportExportKey):
                    this.ActiveConfiguration = this.executiveUtilities.GetDataOr(
                        this.configurationModel.ImportExportKey,
                        (_) => new NotSupportedExecutive()).DataConfiguration;

                    if (this.Stats.Any())
                    {
                        // TODO --> make the stats model supply methods for getting data out of the AccessorCollection
                        //   instead of supplying the entire collection
                        this.DataAccessorCollection = this.dataAccessorLibrary[this.Stats.FirstOrDefault().GetType()];
                    }
                    break;
            }
        }
    }
}
