namespace DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors
{
    public interface IQueryableStandardScraperFlavor : IScraperFlavor { }
    public class QueryableStandardScraperFlavor : ScraperFlavor<QueryableStandardScraperFlavor>, IQueryableStandardScraperFlavor
    {
        public override string Name => "Standard Queryable";
    }
}
