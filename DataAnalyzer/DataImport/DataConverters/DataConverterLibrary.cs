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
using DataScraper.DataScrapers.ScraperFlavors.JsonFlavors;
using DataAnalyzer.DataImport.DataConverters.ClassDataConverters;

namespace DataAnalyzer.DataImport.DataConverters
{
    internal class DataConverterLibrary : FlavoredCategorizedDataLibrary<IDataConverter>, IDataConverterLibrary
    {
        public DataConverterLibrary()
        {
            FileImportType fileType = new();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDataConverter>>();
            InitializeCategory(fileType, new QueryableScraperCategory())
                .AddFlavoredData(new QueryableStandardScraperFlavor(), new QueryableTimeStatsConverter());
            
            InitializeCategory(fileType, new CsvNamesScraperCategory())
                .AddFlavoredData(new CsvNamesStandardScraperFlavor(), new CsvToNameListConverter());
            
            InitializeCategory(fileType, new CsvScraperCategory())
                .AddFlavoredData(new CsvTestScraperFlavor(), new CsvToTestConverter());
            
            InitializeCategory(fileType, new JsonObjectScraperCategory())
                .AddFlavoredData(new JsonGeneralObjectScraperFlavor(), new ClassDataConverter());
        }

        public override string Name => "Data Converter";
    }
}
