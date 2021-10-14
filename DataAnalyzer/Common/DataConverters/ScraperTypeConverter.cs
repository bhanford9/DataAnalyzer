namespace DataAnalyzer.Common.DataConverters
{
  public class ScraperTypeConverter
  {
    public static Services.ScraperType ToAnalyzerData(DataScraper.DataScrapers.ScraperType type)
    {
      return type switch
      {
        DataScraper.DataScrapers.ScraperType.Queryable => Services.ScraperType.Queryable,
        _ => Services.ScraperType.NotApplicable
      };
    }
  }
}
