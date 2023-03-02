namespace DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class ContainerConverter
    {
        public static DataObjects.TimeStats.QueryableTimeStats.ContainerType ToAnalyzerData(DataScraper.Data.TimeData.QueryableData.ContainerType type) => type switch
        {
            DataScraper.Data.TimeData.QueryableData.ContainerType.Array => DataObjects.TimeStats.QueryableTimeStats.ContainerType.Array,
            DataScraper.Data.TimeData.QueryableData.ContainerType.Deque => DataObjects.TimeStats.QueryableTimeStats.ContainerType.Deque,
            DataScraper.Data.TimeData.QueryableData.ContainerType.List => DataObjects.TimeStats.QueryableTimeStats.ContainerType.List,
            DataScraper.Data.TimeData.QueryableData.ContainerType.MultiSet => DataObjects.TimeStats.QueryableTimeStats.ContainerType.MultiSet,
            DataScraper.Data.TimeData.QueryableData.ContainerType.Set => DataObjects.TimeStats.QueryableTimeStats.ContainerType.Set,
            _ => DataObjects.TimeStats.QueryableTimeStats.ContainerType.Vector,
        };
    }
}
