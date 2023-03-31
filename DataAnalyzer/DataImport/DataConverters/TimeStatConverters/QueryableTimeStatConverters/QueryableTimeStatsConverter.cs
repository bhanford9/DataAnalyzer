using DataScraper.Data.TimeData.QueryableData;
using DataScraper.Data;
using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.DataImport.DataObjects;

namespace DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class QueryableTimeStatsConverter : TimeStatsConverter<QueryableTimeStats, QueryableTimeData>, IQueryableTimeStatsConverter
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

        public override bool IsValidData(IData timeData) => timeData is QueryableTimeData;
    }
}
