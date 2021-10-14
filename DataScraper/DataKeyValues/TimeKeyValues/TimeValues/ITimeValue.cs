namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public interface ITimeValue<T>
  {
    T Value { get; set; }

    T ExtractValue(string str);
  }
}