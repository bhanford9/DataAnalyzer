using DataCategory = DataScraper.Data.TimeData.QueryableData;
using StatsCategory = DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;

namespace DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters;

internal class CategoryConverter
{
    public static StatsCategory.CategoryType ToAnalyzerData(DataCategory.CategoryType type) => type switch
    {
        DataCategory.CategoryType.BuiltIn => StatsCategory.CategoryType.BuiltIn,
        DataCategory.CategoryType.Class => StatsCategory.CategoryType.Class,
        _ => StatsCategory.CategoryType.Other,
    };
}
