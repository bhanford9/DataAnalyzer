namespace DataAnalyzer.Common.DataConverters
{
    internal class ScraperTypeConverter
    {
        public static Services.ScraperType ToAnalyzerData(DataScraper.DataScrapers.ScraperType type) =>
            type switch
            {
                DataScraper.DataScrapers.ScraperType.Queryable => Services.ScraperType.Queryable,
                DataScraper.DataScrapers.ScraperType.CsvNames => Services.ScraperType.CsvNames,
                _ => Services.ScraperType.NotApplicable
            };

        public static DataScraper.DataScrapers.ScraperType ToExternalType(Services.ScraperType type) =>
            type switch
            {
                Services.ScraperType.Queryable => DataScraper.DataScrapers.ScraperType.Queryable,
                Services.ScraperType.CsvNames => DataScraper.DataScrapers.ScraperType.CsvNames,
                _ => DataScraper.DataScrapers.ScraperType.NotApplicable
            };
    }
}
