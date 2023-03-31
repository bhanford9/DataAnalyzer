using DataScraper.Data;

namespace DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal interface IQueryableTimeStatsConverter : ITimeStatsConverter
    {
        bool IsValidData(IData timeData);
    }
}