using System.Collections.Generic;
using DataScraper.DataScrapers.CsvDataScrapers;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.TimeDataScrapers;

namespace DataScraper.DataScrapers
{
    public class ScraperLibrary : FlavoredCategorizedDataLibrary<IDataScraper>
    {
        public ScraperLibrary()
        {
            FileImportType fileType = new FileImportType();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDataScraper>>();
            this.InitializeCategory(fileType, new QueryableScraperCategory())
                .ThenAdd(new QueryableStandardScraperFlavor(), new QueryableDataScraper());
            this.InitializeCategory(fileType, new CsvNamesScraperCategory())
                .ThenAdd(new CsvNamesStandardScraperFlavor(), new CsvNamesScraper());
            this.InitializeCategory(fileType, new CsvScraperCategory())
                .ThenAdd(new CsvTestScraperFlavor(), new CsvTestScraper());
        }

        public override string Name => "Scraper";
    }
}
