using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;

namespace DataScraper.DataScrapers.ScraperFlavors
{
    public class NotApplicableScraperFlavor : ScraperFlavor<CsvTestScraperFlavor>
    {
        public override string Name => "Not Applicable";
    }
}
