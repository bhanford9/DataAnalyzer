namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public class IntTimeValue : TimeValue<int>
  {
    public override int ExtractValue(string str)
    {
      return int.Parse(str);
    }
  }
}
