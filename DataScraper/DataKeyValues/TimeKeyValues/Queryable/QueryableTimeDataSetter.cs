using System;
using System.Collections.Generic;
using DataScraper.Data.TimeData.QueryableData;
using DataScraper.DataKeyValues.TimeKeyValues.StandardValues;
using DataScraper.DataKeyValues.TimeKeyValues.TimeValues;

namespace DataScraper.DataKeyValues.TimeKeyValues.Queryable;

public class QueryableTimeDataSetter
{
    private readonly IDictionary<string, Action<QueryableTimeData, string>> setters = new Dictionary<string, Action<QueryableTimeData, string>>();

    public QueryableTimeDataSetter()
    {
        this.setters.Add(QueryableTimeDataKeys.CATEGORY, (timeData, valueString) => timeData.CategoryType = new QueryableCategoryValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.CONTAINER, (timeData, valueString) => timeData.ContainerType = new QueryableContainerValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.METHOD, (timeData, valueString) => timeData.MethodName = new StringValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.TRIGGER, (timeData, valueString) => timeData.TriggerType = new QueryableTriggerValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.CONTAINER_SIZE, (timeData, valueString) => timeData.ContainerSize = new IntValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.ITERATIONS, (timeData, valueString) => timeData.Iterations = new IntValue().ExtractValue(valueString));

        this.setters.Add(QueryableTimeDataKeys.STANDARD_TOTAL_MILLIS, (timeData, valueString) => timeData.TotalTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.STANDARD_AVERAGE_MILLIS, (timeData, valueString) => timeData.AverageTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.STANDARD_FASTEST_MILLIS, (timeData, valueString) => timeData.FastestTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.STANDARD_SLOWEST_MILLIS, (timeData, valueString) => timeData.SlowestTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.STANDARD_RANGE_MILLIS, (timeData, valueString) => timeData.RangeTimeMillis = new DoubleValue().ExtractValue(valueString));

        this.setters.Add(QueryableTimeDataKeys.QUERYABLE_TOTAL_MILLIS, (timeData, valueString) => timeData.TotalTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.QUERYABLE_AVERAGE_MILLIS, (timeData, valueString) => timeData.AverageTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.QUERYABLE_FASTEST_MILLIS, (timeData, valueString) => timeData.FastestTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.QUERYABLE_SLOWEST_MILLIS, (timeData, valueString) => timeData.SlowestTimeMillis = new DoubleValue().ExtractValue(valueString));
        this.setters.Add(QueryableTimeDataKeys.QUERYABLE_RANGE_MILLIS, (timeData, valueString) => timeData.RangeTimeMillis = new DoubleValue().ExtractValue(valueString));
    }

    public void Set(QueryableTimeData timeData, string key, string value)
    {
        this.setters[key](timeData, value);
    }
}
