using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.DataImport.DataObjects;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;
using System.Collections.Generic;

namespace DataAnalyzer.Services;

internal interface IScraperService
{
    IReadOnlyCollection<IScraperCategory> GetCategoriesForType(IImportType type);
    IReadOnlyCollection<IScraperFlavor> GetFlavorsForCategory(IImportType type, IScraperCategory category);
    IReadOnlyDictionary<IScraperCategory, ICollection<IScraperFlavor>> GetMapForType(IImportType type);
    IDataScraper GetScraper(IImportType type, IScraperCategory category, IScraperFlavor flavor);
    IDataScraper GetScraper(ImportKey importKey);
    ICollection<IStats> ScrapeFromSource(IDataSource source, IImportType type, IScraperCategory category, IScraperFlavor flavor);
    ICollection<IStats> ScrapeFromSource(IDataSource source, ImportKey key);
    bool TryScrapeFromSource(IDataSource source, IDataConverter converter, IImportType type, IScraperCategory category, IScraperFlavor flavor, out ICollection<IStats> stats);
}