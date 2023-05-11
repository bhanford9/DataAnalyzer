namespace DataScraper.DataScrapers.ScraperCategories;

public interface INotApplicableScraperCategory : IScraperCategory { }
public class NotApplicableScraperCategory : ScraperCategory<CsvScraperCategory>, INotApplicableScraperCategory
{
    public override string Name => "Not Applicable";
}
