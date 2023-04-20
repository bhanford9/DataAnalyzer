using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

namespace DataScraper.DataScrapers.ScraperFlavors
{
    public interface INotApplicableScraperFlavor : IScraperFlavor { }
    public class NotApplicableScraperFlavor : ScraperFlavor<CsvTestScraperFlavor>, INotApplicableScraperFlavor
    {
        public override string Name => "Not Applicable";
    }
}
