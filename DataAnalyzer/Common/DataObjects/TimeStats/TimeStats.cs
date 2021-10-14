namespace DataAnalyzer.Common.DataObjects.TimeStats
{
  public class TimeStats : ITimeStats
  {
    public int Iterations { get; set; }

    public int ContainerSize { get; set; }

    public double TotalTimeMillis { get; set; }

    public double AverageTimeMillis { get; set; }

    public double FastestTimeMillis { get; set; }

    public double SlowestTimeMillis { get; set; }

    public double RangeTimeMillis { get; set; }

    public string ExecuterName { get; set; } = string.Empty;
  }
}
