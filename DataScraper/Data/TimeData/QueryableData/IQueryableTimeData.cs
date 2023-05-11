namespace DataScraper.Data.TimeData.QueryableData;

public interface IQueryableTimeData : ITimeData
{
    CategoryType CategoryType { get; set; }
    ContainerType ContainerType { get; set; }
    string MethodName { get; set; }
    TriggerType TriggerType { get; set; }
}