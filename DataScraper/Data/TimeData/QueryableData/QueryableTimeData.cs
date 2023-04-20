namespace DataScraper.Data.TimeData.QueryableData
{
    public class QueryableTimeData : TimeData, IQueryableTimeData
    {
        public CategoryType CategoryType { get; set; } = CategoryType.Other;

        public ContainerType ContainerType { get; set; } = ContainerType.Vector;

        public TriggerType TriggerType { get; set; } = TriggerType.NotApplicable;

        public string MethodName { get; set; } = string.Empty;
    }
}
