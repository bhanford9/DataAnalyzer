using System.Collections.Generic;
using System.Linq;
using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
  public class StatsModel : BasePropertyChanged
  {
    private readonly ScraperService scraperService = new ScraperService();
    private readonly ICollection<IStats> stats = new List<IStats>();

    public StatsModel()
    {
    }

    public ICollection<IStats> Stats => this.stats;

    public void ClearLoadedStats()
    {
      this.stats.Clear();

      this.NotifyPropertyChanged(nameof(this.Stats));
    }

    public void LoadStatsForFile(string filePath, IDataConverter converter)
    {
      this.scraperService.ScrapeFromFile(filePath, converter)
        .ToList()
        .ForEach(stats.Add);

      this.NotifyPropertyChanged(nameof(this.Stats));
    }
  }
}
