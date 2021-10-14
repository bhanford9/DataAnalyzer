namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public class StringTimeValue : TimeValue<string>
  {
    public override string ExtractValue(string str)
    {
      return str;
    }
  }
}
