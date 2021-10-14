using System;
using System.Collections.Generic;
using DataScraper.Data.TimeData.QueryableData;
using DataScraper.DataKeyValues.TimeKeyValues.TimeValues;

namespace DataScraper.DataKeyValues.TimeKeyValues.Queryable
{
  public class QueryableTimeDataSetter
  {
    private readonly IDictionary<string, Action<QueryableTimeData, string>> setters = new Dictionary<string, Action<QueryableTimeData, string>>();

    public QueryableTimeDataSetter()
    {
      setters.Add(QueryableTimeDataKeys.CATEGORY, (timeData, valueString) => timeData.CategoryType = new QueryableCategoryTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.CONTAINER, (timeData, valueString) => timeData.ContainerType = new QueryableContainerTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.METHOD, (timeData, valueString) => timeData.MethodName = new StringTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.TRIGGER, (timeData, valueString) => timeData.TriggerType = new QueryableTriggerTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.CONTAINER_SIZE, (timeData, valueString) => timeData.ContainerSize = new IntTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.ITERATIONS, (timeData, valueString) => timeData.Iterations = new IntTimeValue().ExtractValue(valueString));

      setters.Add(QueryableTimeDataKeys.STANDARD_TOTAL_MILLIS, (timeData, valueString) => timeData.TotalTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.STANDARD_AVERAGE_MILLIS, (timeData, valueString) => timeData.AverageTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.STANDARD_FASTEST_MILLIS, (timeData, valueString) => timeData.FastestTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.STANDARD_SLOWEST_MILLIS, (timeData, valueString) => timeData.SlowestTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.STANDARD_RANGE_MILLIS, (timeData, valueString) => timeData.RangeTimeMillis = new DoubleTimeValue().ExtractValue(valueString));

      setters.Add(QueryableTimeDataKeys.QUERYABLE_TOTAL_MILLIS, (timeData, valueString) => timeData.TotalTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.QUERYABLE_AVERAGE_MILLIS, (timeData, valueString) => timeData.AverageTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.QUERYABLE_FASTEST_MILLIS, (timeData, valueString) => timeData.FastestTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.QUERYABLE_SLOWEST_MILLIS, (timeData, valueString) => timeData.SlowestTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
      setters.Add(QueryableTimeDataKeys.QUERYABLE_RANGE_MILLIS, (timeData, valueString) => timeData.RangeTimeMillis = new DoubleTimeValue().ExtractValue(valueString));
    }

    public void Set(QueryableTimeData timeData, string key, string value)
    {
      this.setters[key](timeData, value);
    }
  }
}
