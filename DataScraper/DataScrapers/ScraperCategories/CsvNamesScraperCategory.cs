namespace DataScraper.DataScrapers.ScraperCategories;

public interface ICsvNamesScraperCategory : IScraperCategory { }
public class CsvNamesScraperCategory : ScraperCategory<CsvNamesScraperCategory>, ICsvNamesScraperCategory
{
    public override string Name => "CSV Names Scraper";
}
