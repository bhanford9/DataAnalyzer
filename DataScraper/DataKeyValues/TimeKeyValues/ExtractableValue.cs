namespace DataScraper.DataKeyValues.TimeKeyValues;

public abstract class ExtractableValue<T> : IExtractableValue<T>
{
    public abstract T ExtractValue(string str);
}
