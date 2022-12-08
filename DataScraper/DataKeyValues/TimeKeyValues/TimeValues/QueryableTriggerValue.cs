using DataScraper.Data.TimeData.QueryableData;

namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
    public class QueryableTriggerValue : ExtractableValue<TriggerType>
    {
        public override TriggerType ExtractValue(string str)
        {
            return str switch
            {
                "Begin" => TriggerType.Begin,
                "Quarter" => TriggerType.Quarter,
                "Half" => TriggerType.Half,
                "ThreeQuarter" => TriggerType.ThreeQuarter,
                "End" => TriggerType.End,
                "Never" => TriggerType.Never,
                "LowFrequency" => TriggerType.LowFrequency,
                "MediumFrequency" => TriggerType.MediumFrequency,
                "HighFrequency" => TriggerType.HighFrequency,
                _ => TriggerType.NotApplicable,
            };
        }
    }
}
