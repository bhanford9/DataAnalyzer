namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public abstract class TimeValue<T> : ITimeValue<T>
  {
    public T Value { get; set; }

    public abstract T ExtractValue(string str);
  }
}
