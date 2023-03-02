using System.Collections.Generic;
using DataAnalyzer.Common.DataConverters.CsvConverters;
using DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters;
using DataScraper;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

namespace DataAnalyzer.Common.DataConverters
{
    // TODO --> this should be a 1-to-1 mapping with ScraperLibrary 
    internal class DataConverterLibrary : FlavoredCategorizedDataLibrary<IDataConverter>
    {
        public DataConverterLibrary()
        {
            FileImportType fileType = new FileImportType();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDataConverter>>();
            this.InitializeCategory(fileType, new QueryableScraperCategory())
                .ThenAdd(new QueryableStandardScraperFlavor(), new QueryableTimeStatsConverter());
            this.InitializeCategory(fileType, new CsvNamesScraperCategory())
                .ThenAdd(new CsvNamesStandardScraperFlavor(), new CsvToNameListConverter());
            this.InitializeCategory(fileType, new CsvScraperCategory())
                .ThenAdd(new CsvTestScraperFlavor(), new CsvToTestConverter());
        }
    }
}
