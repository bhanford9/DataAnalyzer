using DataScraper.Data;
using DataScraper.DataSources;
using System.Collections.Generic;

namespace DataScraper.DataScrapers
{
    public interface IDataScraper
    {
        string Name { get; }

        ICollection<IData> ScrapeFromSource(IDataSource source);
    }
}
