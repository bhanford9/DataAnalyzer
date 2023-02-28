using DataScraper.Data.TimeData.QueryableData;
using DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;

namespace DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class QueryableTimeStatsConverter : TimeStatsConverter
    {
        protected override void InternalToAnalyzer(IData timeData, IStats timeStats)
        {
            QueryableTimeData inData = timeData as QueryableTimeData;
            QueryableTimeStats outData = timeStats as QueryableTimeStats;

            outData.CategoryType = CategoryConverter.ToAnalyzerData(inData.CategoryType);
            outData.ContainerType = ContainerConverter.ToAnalyzerData(inData.ContainerType);
            outData.TriggerType = TriggerConverter.ToAnalyzerData(inData.TriggerType);
            outData.MethodName = inData.MethodName;
        }

        public override bool IsValidData(IData timeData)
        {
            return timeData is QueryableTimeData;
        }

        public override IStats InstantiateStats()
        {
            return new QueryableTimeStats();
        }

        public override IData InstantiateData()
        {
            return new QueryableTimeData();
        }
    }
}
