using DataAnalyzer.Common.DataObjects.TimeStats;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
  public class TimeParameters : DataParameterCollection<TimeStats>
  {
    protected override void InitializeParameters()
    {
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.Iterations) });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.ContainerSize) });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.TotalTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.AverageTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.FastestTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.SlowestTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.RangeTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter() { Name = nameof(TimeStats.ExecuterName) });
    }
  }
}
