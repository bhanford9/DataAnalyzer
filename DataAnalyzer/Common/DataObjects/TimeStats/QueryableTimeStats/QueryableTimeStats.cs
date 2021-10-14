namespace DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats
{
  public class QueryableTimeStats : TimeStats
  {
    public CategoryType CategoryType { get; set; } = CategoryType.Other;

    public ContainerType ContainerType { get; set; } = ContainerType.Vector;

    public TriggerType TriggerType { get; set; } = TriggerType.NotApplicable;

    public string MethodName { get; set; } = string.Empty;
  }
}
