using DataScraper.Data;
using DataScraper.DataSources;

namespace DataScraper.DataScrapers
{
    public interface IDataScraper
    {
        string Name { get; }

        bool IsValidSource(IDataSource source);

        ICollection<IData> ScrapeFromSource(IDataSource source);
    }
}
