namespace DataScraper.DataScrapers.ScraperCategories;

public interface IJsonObjectScraperCategory : IScraperCategory { }
public class JsonObjectScraperCategory : ScraperCategory<JsonObjectScraperCategory>, IJsonObjectScraperCategory
{
    public override string Name => "JSON General Object Scraper";
}
