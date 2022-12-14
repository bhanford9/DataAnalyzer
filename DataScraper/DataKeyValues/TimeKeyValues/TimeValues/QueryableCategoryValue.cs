using DataScraper.Data.TimeData.QueryableData;

namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
    public class QueryableCategoryValue : ExtractableValue<CategoryType>
    {
        public override CategoryType ExtractValue(string str)
        {
            return str switch
            {
                "BuiltIn" => CategoryType.BuiltIn,
                //"BuiltInTypeWithMediumLoad" => CategoryType.BuiltInMediumLoad,
                //"BuiltInTypeWithHeavyLoad" => CategoryType.BuiltInHeavyLoad,
                "Class" => CategoryType.Class,
                //"ClassTypeWithMediumLoad" => CategoryType.ClassMediumLoad,
                //"ClassTypeWithHeavyLoad" => CategoryType.ClassHeavyLoad,
                _ => CategoryType.Other,
            };
        }
    }
}
