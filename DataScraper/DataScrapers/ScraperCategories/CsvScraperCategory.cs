namespace DataScraper.DataScrapers.ScraperCategories;

public interface ICsvScraperCategory : IScraperCategory { }
public class CsvScraperCategory : ScraperCategory<CsvScraperCategory>, ICsvScraperCategory
{
    public override string Name => "CSV Scraper";
}