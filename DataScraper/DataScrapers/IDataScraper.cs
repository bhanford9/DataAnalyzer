using DataScraper.Data;
using DataScraper.DataSources;
using System.Collections.Generic;

namespace DataScraper.DataScrapers;

public interface IDataScraper
{
    string Name { get; }

    bool IsValidSource(IDataSource source);

    ICollection<IData> ScrapeFromSource(IDataSource source);
}
