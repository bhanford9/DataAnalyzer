namespace DataAnalyzer.Common.DataObjects.TimeStats
{
  public interface ITimeStats : IStats
  {
    double AverageTimeMillis { get; set; }
    int ContainerSize { get; set; }
    string ExecuterName { get; set; }
    double FastestTimeMillis { get; set; }
    int Iterations { get; set; }
    double RangeTimeMillis { get; set; }
    double SlowestTimeMillis { get; set; }
    double TotalTimeMillis { get; set; }
  }
}