namespace DataScraper.DataScrapers.ScraperCategories;

public abstract class ScraperCategory<T> : ScraperKey<T>, IScraperCategory
     where T : IScraperCategory, new()
{
}
