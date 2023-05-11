namespace DataScraper.DataKeyValues.TimeKeyValues.StandardValues;

public class IntValue : ExtractableValue<int>
{
    public override int ExtractValue(string str)
    {
        return int.Parse(str);
    }
}
