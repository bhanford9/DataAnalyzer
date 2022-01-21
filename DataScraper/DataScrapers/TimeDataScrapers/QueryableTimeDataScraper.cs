using System.Collections.Generic;
using System.IO;
using DataScraper.Data;
using DataScraper.Data.TimeData.QueryableData;
using DataScraper.DataKeyValues.TimeKeyValues.Queryable;

namespace DataScraper.DataScrapers.TimeDataScrapers
{
  public class QueryableDataScraper : IDataScraper
  {
    private const string STD_LIB_NAME = "Standard Library";
    private const string QUERYABLE_LIB_NAME = "Queryable Library";

    public ScraperType ScraperType => ScraperType.Queryable;

    public ICollection<IData> ScrapeFromFile(string filePath)
    {
      ICollection<IData> timeData = new List<IData>();
      QueryableTimeDataSetter dataSetter = new QueryableTimeDataSetter();
      QueryableTimeData standardTimeDatum = new QueryableTimeData { ExecuterName = STD_LIB_NAME };
      QueryableTimeData queryableTimeDatum = new QueryableTimeData { ExecuterName = QUERYABLE_LIB_NAME };

      string[] lines = File.ReadAllLines(filePath);

      for (int i = 0; i < lines.Length; i++)
      {
        if (lines[i].Trim().Length == 0)
        {
          timeData.Add(standardTimeDatum);
          timeData.Add(queryableTimeDatum);
          standardTimeDatum = new QueryableTimeData { ExecuterName = STD_LIB_NAME };
          queryableTimeDatum = new QueryableTimeData { ExecuterName = QUERYABLE_LIB_NAME };
          continue;
        }

        string[] keyValue = lines[i].Split(':');
        string key = keyValue[0].Trim();
        string valueString = keyValue[1].Trim();

        switch (key)
        {
          case QueryableTimeDataKeys.CATEGORY:
          case QueryableTimeDataKeys.CONTAINER:
          case QueryableTimeDataKeys.TRIGGER:
          case QueryableTimeDataKeys.METHOD:
          case QueryableTimeDataKeys.CONTAINER_SIZE:
          case QueryableTimeDataKeys.ITERATIONS:
            dataSetter.Set(standardTimeDatum, key, valueString);
            dataSetter.Set(queryableTimeDatum, key, valueString);
            break;
          case QueryableTimeDataKeys.STANDARD_TOTAL_MILLIS:
          case QueryableTimeDataKeys.STANDARD_AVERAGE_MILLIS:
          case QueryableTimeDataKeys.STANDARD_FASTEST_MILLIS:
          case QueryableTimeDataKeys.STANDARD_SLOWEST_MILLIS:
          case QueryableTimeDataKeys.STANDARD_RANGE_MILLIS:
            dataSetter.Set(standardTimeDatum, key, valueString);
            break;
          case QueryableTimeDataKeys.QUERYABLE_TOTAL_MILLIS:
          case QueryableTimeDataKeys.QUERYABLE_AVERAGE_MILLIS:
          case QueryableTimeDataKeys.QUERYABLE_FASTEST_MILLIS:
          case QueryableTimeDataKeys.QUERYABLE_SLOWEST_MILLIS:
          case QueryableTimeDataKeys.QUERYABLE_RANGE_MILLIS:
            dataSetter.Set(queryableTimeDatum, key, valueString);
            break;
        }
      }

      return timeData;
    }
  }
}
