using System.Collections.Generic;
using System.Linq;
using DataScraper.DataScrapers.TimeDataScrapers;

namespace DataScraper.DataScrapers
{
  public class ScraperLibrary
  {
    private readonly ICollection<IDataScraper> scrapers = new List<IDataScraper>();

    private void LoadScrapers()
    {
      this.scrapers.Add(new QueryableDataScraper());
    }

    public ScraperLibrary()
    {
      this.LoadScrapers();
    }

    public IDataScraper GetScraper(ScraperType type)
    {
      return this.scrapers.First(x => x.ScraperType == type);
    }
  }
}
