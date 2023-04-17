using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.StatConfigurations;
using DataScraper.DataSources;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.Models
{
    internal class StatsModel : BasePropertyChanged, IStatsModel
    {
        private readonly IConfigurationModel configurationModel;
        private readonly ScraperService scraperService = new();
        private HeirarchalStats heirarchalStats;

        private IDataConfiguration activeConfiguration = new NotSupportedDataConfiguration();

        //  making this lazy because it instantiates classes that require this model already be in memory
        private IExecutiveUtilitiesRepository executiveUtilities;

        public StatsModel(
            IConfigurationModel configModel,
            IExecutiveUtilitiesRepository executiveUtilities)
        {
            this.configurationModel = configModel;
            this.executiveUtilities = executiveUtilities;
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
            this.Stats.Clear();

            this.scraperService.ScrapeFromSource(source, this.configurationModel.ImportExportKey.ImportKey)
                .ToList()
                .ForEach(this.Stats.Add);

            this.NotifyPropertyChanged(nameof(this.Stats));
        }

        public void StructureStats(AppDataConfig.IDataConfiguration applicationConfiguration)
        {
            this.activeConfiguration.Initialize(this.configurationModel.DataParameterCollection, applicationConfiguration);

            this.HeirarchalStats = this.executiveUtilities
                .GetDataOrDefault(this.configurationModel.ImportExportKey)
                .DataOrganizer.Organize(this.activeConfiguration, this.Stats);

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

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportExportKey):
                    this.ActiveConfiguration = this.executiveUtilities
                        .GetDataOrDefault(this.configurationModel.ImportExportKey)
                        .DataConfiguration;
                    break;
            }
        }
    }
}
