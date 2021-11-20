using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataConfigurations.ExcelConfiguration;
using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
  public class StatsModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly ScraperService scraperService = new ScraperService();
    private readonly ICollection<IStats> stats = new List<IStats>();

    private HeirarchalStats heirarchalStats;

    public StatsModel()
    {
    }

    public ICollection<IStats> Stats => this.stats;

    public ObservableCollection<string> StatNames { get; }
      = new ObservableCollection<string>();

    public HeirarchalStats HeirarchalStats
    {
      get => this.heirarchalStats;
      set => this.NotifyPropertyChanged(nameof(this.HeirarchalStats), ref this.heirarchalStats, value);
    }

    public void ClearLoadedStats()
    {
      this.stats.Clear();

      this.NotifyPropertyChanged(nameof(this.Stats));
    }

    public void LoadStatsForFile(string filePath, IDataConverter converter)
    {
      this.scraperService.ScrapeFromFile(filePath, converter)
        .ToList()
        .ForEach(this.stats.Add);

      this.NotifyPropertyChanged(nameof(this.Stats));
    }

    public void StructureStats()
    {
      ExcelConfiguration configuration = new ExcelConfiguration();
      IDataParameterCollection parameters = this.configurationModel.DataParameterCollection;
      ICollection<GroupingConfiguration> groupings = this.configurationModel.DataConfiguration.GroupingConfiguration;

      for (int i = 0; i < groupings.Count; i++)
      {
        configuration.AddGroupingRule(i, parameters.GetStatAccessor(groupings.ElementAt(i).SelectedParameter));
      }

      DataOrganizer organizer = new DataOrganizer();
      this.HeirarchalStats = organizer.Organize(configuration, this.stats);

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
  }
}
