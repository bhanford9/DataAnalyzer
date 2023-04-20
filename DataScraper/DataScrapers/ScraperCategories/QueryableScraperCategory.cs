namespace DataScraper.DataScrapers.ScraperCategories
{
    public interface IQueryableScraperCategory : IScraperCategory { }
    public class QueryableScraperCategory : ScraperCategory<QueryableScraperCategory>, IQueryableScraperCategory
    {
        public override string Name => "Queryable Scraper";
    }
}
