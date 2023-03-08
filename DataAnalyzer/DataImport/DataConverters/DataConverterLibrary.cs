using System.Collections.Generic;
using DataAnalyzer.DataImport.DataConverters.CsvConverters;
using DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters;
using DataScraper;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

namespace DataAnalyzer.DataImport.DataConverters
{
    internal class DataConverterLibrary : FlavoredCategorizedDataLibrary<IDataConverter>
    {
        public DataConverterLibrary()
        {
            FileImportType fileType = new FileImportType();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDataConverter>>();
            InitializeCategory(fileType, new QueryableScraperCategory())
                .ThenAdd(new QueryableStandardScraperFlavor(), new QueryableTimeStatsConverter());
            InitializeCategory(fileType, new CsvNamesScraperCategory())
                .ThenAdd(new CsvNamesStandardScraperFlavor(), new CsvToNameListConverter());
            InitializeCategory(fileType, new CsvScraperCategory())
                .ThenAdd(new CsvTestScraperFlavor(), new CsvToTestConverter());
        }

        public override string Name => "Data Converter";
    }
}
