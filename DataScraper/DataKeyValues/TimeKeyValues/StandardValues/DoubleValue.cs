namespace DataScraper.DataKeyValues.TimeKeyValues.StandardValues;

public class DoubleValue : ExtractableValue<double>
{
    public override double ExtractValue(string str)
    {
        return double.Parse(str);
    }
}
