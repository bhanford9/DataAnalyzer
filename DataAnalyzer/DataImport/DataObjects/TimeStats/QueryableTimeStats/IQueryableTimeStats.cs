namespace DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;

internal interface IQueryableTimeStats : ITimeStats
{
    CategoryType CategoryType { get; set; }
    ContainerType ContainerType { get; set; }
    string MethodName { get; set; }
    TriggerType TriggerType { get; set; }
}