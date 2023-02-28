using System.Collections.Generic;
using System.Linq;
using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.DataObjects;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;

namespace DataAnalyzer.Services
{
    internal class ScraperService
    {
        // TODO --> looks like I may want to put ScraperType into the library and create a dict of dicts
        private readonly ScraperLibrary scraperLibrary = new();

        public IDataScraper GetScraper(IImportType type, IScraperCategory category, IScraperFlavor flavor)
            => scraperLibrary[type, category, flavor];

        public IReadOnlyDictionary<IScraperCategory, ICollection<IScraperFlavor>> GetMapForType(IImportType type)
            => scraperLibrary[type].ToDictionary(x => x.Key, x => x.Value.Keys);

        public IReadOnlyCollection<IScraperCategory> GetCategoriesForType(IImportType type)
            => scraperLibrary[type].Keys.ToList();

        public IReadOnlyCollection<IScraperFlavor> GetFlavorsForCategory(IImportType type, IScraperCategory category)
            => scraperLibrary[type][category].Keys.ToList();

        public ICollection<IStats> ScrapeFromSource(
            IDataSource source,
            IDataConverter converter,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor)
        {
            IDataScraper scraper = this.scraperLibrary[type, category, flavor];
            return converter.ToAnalyzerStats(scraper.ScrapeFromSource(source));
        }
    }
}
