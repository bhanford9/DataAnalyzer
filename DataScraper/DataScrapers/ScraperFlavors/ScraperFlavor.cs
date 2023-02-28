namespace DataScraper.DataScrapers.ScraperFlavors
{
    public abstract class ScraperFlavor<T> : ScraperKey<T>, IScraperFlavor
         where T : IScraperFlavor, new()
    {
    }
}
