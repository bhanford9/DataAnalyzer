namespace DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class CategoryConverter
    {
        public static DataObjects.TimeStats.QueryableTimeStats.CategoryType ToAnalyzerData(DataScraper.Data.TimeData.QueryableData.CategoryType type)
        {
            return type switch
            {
                DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltInLowLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltInLowLoad,
                DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltInMediumLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltInMediumLoad,
                DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltInHeavyLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltInHeavyLoad,
                DataScraper.Data.TimeData.QueryableData.CategoryType.ClassLowLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.ClassLowLoad,
                DataScraper.Data.TimeData.QueryableData.CategoryType.ClassMediumLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.ClassMediumLoad,
                DataScraper.Data.TimeData.QueryableData.CategoryType.ClassHeavyLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.ClassHeavyLoad,
                _ => DataObjects.TimeStats.QueryableTimeStats.CategoryType.Other,
            };
        }
    }
}
