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
    public class ScraperExecutive
    {
        static ScraperExecutive() { }
     
        public ScraperLibrary Scrapers { get; } = new();

        public ICollection<IData> ScrapeOutData(
            IDataSource source,
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor)
        {
            IDataScraper scraper;

            try
            {
                scraper = this.Scrapers[type, category, flavor];
            }
            catch
            {
                throw new ArgumentOutOfRangeException(
                    "Failed to retrieve scraper with provided parameters. Make sure scraper library contains specified arguments." +
                    $"{Environment.NewLine}\tType: {type}" +
                    $"{Environment.NewLine}\tCategory: {category}" +
                    $"{Environment.NewLine}\tFlavor: {flavor}");
            }

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
            IDataScraper scraper;

            try
            {
                scraper = this.Scrapers[type, category, flavor];
            }
            catch
            {
                return false;
            }

            if (scraper.IsValidSource(source))
            {
                data = scraper.ScrapeFromSource(source);
                return true;
            }

            return false;
        }
    }
}
