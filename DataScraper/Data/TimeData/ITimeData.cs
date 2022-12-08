namespace DataScraper.Data.TimeData
{
    public interface ITimeData : IData
    {
        double AverageTimeMillis { get; set; }
        int ContainerSize { get; set; }
        double FastestTimeMillis { get; set; }
        int Iterations { get; set; }
        double RangeTimeMillis { get; set; }
        double SlowestTimeMillis { get; set; }
        double TotalTimeMillis { get; set; }
        string ExecuterName { get; set; }
    }
}