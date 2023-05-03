namespace DataScraper.DataScrapers.ScraperFlavors.JsonFlavors
{
    public interface IJsonGeneralObjectScraperFlavor : IScraperFlavor { }
    public class JsonGeneralObjectScraperFlavor : ScraperFlavor<JsonGeneralObjectScraperFlavor>, IJsonGeneralObjectScraperFlavor
    {
        public override string Name => "General JSON Object";
    }
}
