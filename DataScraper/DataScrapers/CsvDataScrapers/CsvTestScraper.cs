using DataScraper.Data;
using DataScraper.DataSources;
using System;
using System.Collections.Generic;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    public class CsvTestScraper : IDataScraper
    {
        public string Name => "Test CSV Scraper";

        public ICollection<IData> ScrapeFromSource(IDataSource source)
        {
            throw new NotImplementedException();
        }
    }
}
