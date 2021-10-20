using DataAnalyzer.Common.DataObjects.TimeStats;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
  public abstract class TimeParameters : DataParameterCollection
  {
    protected override void InitializeParameters()
    {
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).Iterations, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.Iterations) });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).ContainerSize, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.ContainerSize) });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).TotalTimeMillis, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.TotalTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).AverageTimeMillis, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.AverageTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).FastestTimeMillis, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.FastestTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).SlowestTimeMillis, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.SlowestTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).RangeTimeMillis, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.RangeTimeMillis), CanGroupBy = false });
      this.parameters.Add(new DataParameter((stats) => (stats as ITimeStats).ExecuterName, (stats) => stats is ITimeStats) { Name = nameof(TimeStats.ExecuterName) });

      this.InternalInitializeParameters();
    }

    protected abstract void InternalInitializeParameters();
  }
}
