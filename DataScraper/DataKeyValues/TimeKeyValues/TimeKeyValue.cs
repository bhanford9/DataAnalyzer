using DataScraper.DataKeyValues.TimeKeyValues.TimeValues;

namespace DataScraper.DataKeyValues.TimeKeyValues
{
  public class TimeKeyValue
  {
    public TimeKeyValue(string key)
    {
      this.Key = key;
    }

    public bool Retrieved { get; set; } = false;

    public string Key { get; set; }

    public T GetValue<T>(TimeValue<T> timeValue, string stringValue)
    {
      this.Retrieved = true;
      return timeValue.ExtractValue(stringValue);
    }
  }
}
