namespace DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters
{
    internal class CategoryConverter
    {
        public static DataObjects.TimeStats.QueryableTimeStats.CategoryType ToAnalyzerData(DataScraper.Data.TimeData.QueryableData.CategoryType type) => type switch
        {
            DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltIn => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltIn,
            //DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltInMediumLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltInMediumLoad,
            //DataScraper.Data.TimeData.QueryableData.CategoryType.BuiltInHeavyLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.BuiltInHeavyLoad,
            DataScraper.Data.TimeData.QueryableData.CategoryType.Class => DataObjects.TimeStats.QueryableTimeStats.CategoryType.Class,
            //DataScraper.Data.TimeData.QueryableData.CategoryType.ClassMediumLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.ClassMediumLoad,
            //DataScraper.Data.TimeData.QueryableData.CategoryType.ClassHeavyLoad => DataObjects.TimeStats.QueryableTimeStats.CategoryType.ClassHeavyLoad,
            _ => DataObjects.TimeStats.QueryableTimeStats.CategoryType.Other,
        };
    }
}
