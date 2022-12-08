namespace DataScraper.DataKeyValues.TimeKeyValues
{
    public interface IExtractableValue<T>
    {
        T ExtractValue(string str);
    }
}