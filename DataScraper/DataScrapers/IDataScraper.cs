using DataScraper.Data;
using System.Collections.Generic;

namespace DataScraper.DataScrapers
{
    public interface IDataScraper
    {
        ScraperType ScraperType { get; }

        ICollection<IData> ScrapeFromFile(string filePath);
    }
}
