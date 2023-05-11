namespace DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

public interface ICsvTestScraperFlavor : IScraperFlavor { }
public class CsvTestScraperFlavor : ScraperFlavor<CsvTestScraperFlavor>, ICsvTestScraperFlavor
{
    public override string Name => "Csv Test";
}
