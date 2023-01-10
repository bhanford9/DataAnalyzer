using System.Collections.Generic;
using DataScraper.DataScrapers.CsvDataScrapers;
using DataScraper.DataScrapers.TimeDataScrapers;

namespace DataScraper.DataScrapers
{
    public class ScraperLibrary
    {
        private readonly IReadOnlyDictionary<ScraperType, IDataScraper> scrapers;

        public ScraperLibrary()
        {
            this.scrapers = new Dictionary<ScraperType, IDataScraper>()
            {
                { ScraperType.Queryable, new QueryableDataScraper() },
                { ScraperType.CsvNames, new CsvNamesScraper() },
            };
        }

        public IDataScraper GetScraper(ScraperType type)
        {
            return this.scrapers[type];
        }
    }
}
