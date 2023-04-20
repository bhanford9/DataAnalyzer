namespace DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors
{
    public interface ICsvNamesStandardScraperFlavor : IScraperFlavor { }
    public class CsvNamesStandardScraperFlavor : ScraperFlavor<CsvNamesStandardScraperFlavor>, ICsvNamesStandardScraperFlavor
    {
        public override string Name => "Standard Csv Names";
    }
}
