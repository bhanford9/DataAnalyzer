using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.DataImport.DataObjects;
using DataScraper;
using DataScraper.Data;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;

namespace DataAnalyzer.Services
{
    internal class ScraperService : IScraperService
    {
        private readonly IScraperExecutive scraperExecutive;
        private readonly IDataConverterExecutive dataConverterExecutive;
        private readonly IScraperLibrary scraperLibrary;

        public ScraperService(IScraperExecutive scraperExecutive, IDataConverterExecutive dataConverterExecutive)
        {
            this.scraperExecutive = scraperExecutive;
            this.dataConverterExecutive = dataConverterExecutive;
            this.scraperLibrary = this.scraperExecutive.Scrapers;
        }

        public IDataScraper GetScraper(ImportKey importKey) => scraperLibrary.GetData(importKey);

        public IDataScraper GetScraper(IImportType type, IScraperCategory category, IScraperFlavor flavor)
            => scraperLibrary[type, category, flavor];

        public IReadOnlyDictionary<IScraperCategory, ICollection<IScraperFlavor>> GetMapForType(IImportType type)
            => scraperLibrary[type].ToDictionary(x => x.Key, x => x.Value.Keys);

        public IReadOnlyCollection<IScraperCategory> GetCategoriesForType(IImportType type)
            => scraperLibrary[type].Keys.ToList();

        public IReadOnlyCollection<IScraperFlavor> GetFlavorsForCategory(IImportType type, IScraperCategory category)
            => scraperLibrary[type][category].Keys.ToList();

        public ICollection<IStats> ScrapeFromSource(IDataSource source, ImportKey key)
            => ScrapeFromSource(source, key.Type, key.Category, key.Flavor);

        public ICollection<IStats> ScrapeFromSource(
            IDataSource source,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor)
            => dataConverterExecutive.Convert(
                type,
                category,
                flavor,
                scraperExecutive.ScrapeOutData(source, type, category, flavor));

        public bool TryScrapeFromSource(
            IDataSource source,
            IDataConverter converter,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            out ICollection<IStats> stats)
        {
            if (scraperExecutive.TryScrapeOutData(source, type, category, flavor, out ICollection<IData> data))
            {
                stats = converter.ToAnalyzerStats(data);
                return true;
            }

            stats = new List<IStats>();
            return false;
        }
    }
}
