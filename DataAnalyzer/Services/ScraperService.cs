using System.Collections.Generic;
using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.DataObjects;
using DataScraper.DataScrapers;

namespace DataAnalyzer.Services
{
    internal class ScraperService
    {
        private readonly ScraperLibrary scraperLibrary = new ScraperLibrary();

        public ICollection<IStats> ScrapeFromFile(string file, IDataConverter converter)
        {
            IDataScraper scraper = this.scraperLibrary.GetScraper(DataScraper.DataScrapers.ScraperType.Queryable);
            return converter.ToAnalyzerStats(scraper.ScrapeFromFile(file));
        }
    }
}
