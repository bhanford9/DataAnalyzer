using DataScraper.Data.TimeData.QueryableData;

namespace DataScraper.DataKeyValues.TimeKeyValues.TimeValues
{
  public class QueryableContainerValue : ExtractableValue<ContainerType>
  {
    public override ContainerType ExtractValue(string str)
    {
      return str switch
      {
        "Array" => ContainerType.Array,
        "Deque" => ContainerType.Deque,
        "List" => ContainerType.List,
        "MultiSet" => ContainerType.MultiSet,
        "Set" => ContainerType.Set,
        _ => ContainerType.Vector,
      };
    }
  }
}
