using DataContainer = DataScraper.Data.TimeData.QueryableData;
using StatsContainer = DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;

namespace DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class ContainerConverter
    {
        public static StatsContainer.ContainerType ToAnalyzerData(DataContainer.ContainerType type) => type switch
        {
            DataContainer.ContainerType.Array => StatsContainer.ContainerType.Array,
            DataContainer.ContainerType.Deque => StatsContainer.ContainerType.Deque,
            DataContainer.ContainerType.List => StatsContainer.ContainerType.List,
            DataContainer.ContainerType.MultiSet => StatsContainer.ContainerType.MultiSet,
            DataContainer.ContainerType.Set => StatsContainer.ContainerType.Set,
            _ => StatsContainer.ContainerType.Vector,
        };
    }
}
