using DataScraper.Data.TimeData.QueryableData;

namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public class QueryableCategoryTimeValue : TimeValue<CategoryType>
  {
    public override CategoryType ExtractValue(string str)
    {
      return str switch
      {
        "BuiltInTypeWithLowLoad" => CategoryType.BuiltInLowLoad,
        "BuiltInTypeWithMediumLoad" => CategoryType.BuiltInMediumLoad,
        "BuiltInTypeWithHeavyLoad" => CategoryType.BuiltInHeavyLoad,
        "ClassTypeWithLowLoad" => CategoryType.ClassLowLoad,
        "ClassTypeWithMediumLoad" => CategoryType.ClassMediumLoad,
        "ClassTypeWithHeavyLoad" => CategoryType.ClassHeavyLoad,
        _ => CategoryType.Other,
      };
    }
  }
}
