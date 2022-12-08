namespace DataScraper.DataKeyValues.TimeKeyValues.StandardValues
{
    public class StringValue : ExtractableValue<string>
    {
        public override string ExtractValue(string str)
        {
            return str;
        }
    }
}
