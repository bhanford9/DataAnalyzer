using DataScraper.Data;
using DataScraper.DataScrapers;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataSources;
using System;
using System.Collections.Generic;

namespace DataScraper
{
    public class ScraperExecutive : IScraperExecutive
    {
        public ScraperExecutive(IScraperLibrary scraperLibrary)
        {
            this.Scrapers = scraperLibrary;
        }

        public IScraperLibrary Scrapers { get; }

        public ICollection<IData> ScrapeOutData(
            IDataSource source,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor)
        {
            IDataScraper scraper = this.Scrapers.GetData(type, category, flavor);

            if (scraper.IsValidSource(source))
            {
                return scraper.ScrapeFromSource(source);
            }

            throw new ArgumentException("The provided source is an invalid data source");
        }

        public bool TryScrapeOutData(
            IDataSource source,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            out ICollection<IData> data)
        {
            data = new List<IData>();

            if (this.Scrapers.TryGetData(type, category, flavor, out IDataScraper scraper))
            {
                if (scraper.IsValidSource(source))
                {
                    data = scraper.ScrapeFromSource(source);
                    return true;
                }
            }

            return false;
        }
    }
}
