namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public class DoubleTimeValue : TimeValue<double>
  {
    public override double ExtractValue(string str)
    {
      return double.Parse(str);
    }
  }
}
