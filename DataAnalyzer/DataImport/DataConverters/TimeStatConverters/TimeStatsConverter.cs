using DataScraper.Data.TimeData;
using DataScraper.Data;
using DataAnalyzer.DataImport.DataObjects.TimeStats;
using DataAnalyzer.DataImport.DataObjects;

namespace DataAnalyzer.DataImport.DataConverters.TimeStatConverters;

internal abstract class TimeStatsConverter<TTimeStats, TTimeData> : DataConverter<TTimeStats, TTimeData>, ITimeStatsConverter where TTimeStats : ITimeStats, new()
    where TTimeData : ITimeData, new()
{
    protected abstract void InternalToAnalyzer(IData data, IStats stats);

    public override IStats ToAnalyzerStats(IData data)
    {
        if (IsValidData(data))
        {
            ITimeStats stats = InstantiateStats();
            ITimeData timeData = data as ITimeData;

            stats.AverageTimeMillis = timeData.AverageTimeMillis;
            stats.ContainerSize = timeData.ContainerSize;
            stats.ExecuterName = timeData.ExecuterName;
            stats.FastestTimeMillis = timeData.FastestTimeMillis;
            stats.Iterations = timeData.Iterations;
            stats.RangeTimeMillis = timeData.RangeTimeMillis;
            stats.SlowestTimeMillis = timeData.SlowestTimeMillis;
            stats.TotalTimeMillis = timeData.TotalTimeMillis;

            InternalToAnalyzer(timeData, stats);

            return stats;
        }

        throw new System.ArgumentException("Invalid time stats passed in for conversion");
    }
}
