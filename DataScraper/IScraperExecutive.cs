using DataScraper.Data;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;
using System.Collections.Generic;

namespace DataScraper;

public interface IScraperExecutive
{
    IScraperLibrary Scrapers { get; }

    ICollection<IData> ScrapeOutData(IDataSource source, IImportType type, IScraperCategory category, IScraperFlavor flavor);
    bool TryScrapeOutData(IDataSource source, IImportType type, IScraperCategory category, IScraperFlavor flavor, out ICollection<IData> data);
}