namespace DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class TriggerConverter
    {
        public static DataObjects.TimeStats.QueryableTimeStats.TriggerType ToAnalyzerData(DataScraper.Data.TimeData.QueryableData.TriggerType type) => type switch
        {
            DataScraper.Data.TimeData.QueryableData.TriggerType.Begin => DataObjects.TimeStats.QueryableTimeStats.TriggerType.Begin,
            DataScraper.Data.TimeData.QueryableData.TriggerType.Quarter => DataObjects.TimeStats.QueryableTimeStats.TriggerType.Quarter,
            DataScraper.Data.TimeData.QueryableData.TriggerType.Half => DataObjects.TimeStats.QueryableTimeStats.TriggerType.Half,
            DataScraper.Data.TimeData.QueryableData.TriggerType.ThreeQuarter => DataObjects.TimeStats.QueryableTimeStats.TriggerType.ThreeQuarter,
            DataScraper.Data.TimeData.QueryableData.TriggerType.End => DataObjects.TimeStats.QueryableTimeStats.TriggerType.End,
            DataScraper.Data.TimeData.QueryableData.TriggerType.Never => DataObjects.TimeStats.QueryableTimeStats.TriggerType.Never,
            DataScraper.Data.TimeData.QueryableData.TriggerType.LowFrequency => DataObjects.TimeStats.QueryableTimeStats.TriggerType.LowFrequency,
            DataScraper.Data.TimeData.QueryableData.TriggerType.MediumFrequency => DataObjects.TimeStats.QueryableTimeStats.TriggerType.MediumFrequency,
            DataScraper.Data.TimeData.QueryableData.TriggerType.HighFrequency => DataObjects.TimeStats.QueryableTimeStats.TriggerType.HighFrequency,
            _ => DataObjects.TimeStats.QueryableTimeStats.TriggerType.NotApplicable,
        };
    }
}
