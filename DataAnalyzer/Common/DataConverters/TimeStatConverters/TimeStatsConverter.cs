using DataScraper.Data.TimeData;
using DataAnalyzer.Common.DataObjects.TimeStats;
using DataScraper.Data;
using DataAnalyzer.Common.DataObjects;

namespace DataAnalyzer.Common.DataConverters.TimeStatConverters
{
    internal abstract class TimeStatsConverter : DataConverter
    {
        protected abstract void InternalToAnalyzer(IData data, IStats stats);

        public override IStats ToAnalyzerStats(IData data)
        {
            if (this.IsValidData(data))
            {
                ITimeStats stats = this.InstantiateStats() as ITimeStats;
                ITimeData timeData = data as ITimeData;

                stats.AverageTimeMillis = timeData.AverageTimeMillis;
                stats.ContainerSize = timeData.ContainerSize;
                stats.ExecuterName = timeData.ExecuterName;
                stats.FastestTimeMillis = timeData.FastestTimeMillis;
                stats.Iterations = timeData.Iterations;
                stats.RangeTimeMillis = timeData.RangeTimeMillis;
                stats.SlowestTimeMillis = timeData.SlowestTimeMillis;
                stats.TotalTimeMillis = timeData.TotalTimeMillis;

                this.InternalToAnalyzer(timeData, stats);

                return stats;
            }

            throw new System.ArgumentException("Invalid time stats passed in for conversion");
        }
    }
}
