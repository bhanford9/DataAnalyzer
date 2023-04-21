using DataAnalyzer.DataImport.DataObjects.TimeStats;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
    internal abstract class TimeParameters<T> : DataParameterCollection<T>, ITimeParameters where T : ITimeStats
    {
        internal override void AddParameters()
        {
            this.parameters.Add(new DataParameter<T>(stats => stats.Iterations, stats => true) { Name = nameof(TimeStats.Iterations) });
            this.parameters.Add(new DataParameter<T>(stats => stats.ContainerSize, stats => true) { Name = nameof(TimeStats.ContainerSize) });
            this.parameters.Add(new DataParameter<T>(stats => stats.TotalTimeMillis, stats => true) { Name = nameof(TimeStats.TotalTimeMillis), CanGroupBy = false });
            this.parameters.Add(new DataParameter<T>(stats => stats.AverageTimeMillis, stats => true) { Name = nameof(TimeStats.AverageTimeMillis), CanGroupBy = false });
            this.parameters.Add(new DataParameter<T>(stats => stats.FastestTimeMillis, stats => true) { Name = nameof(TimeStats.FastestTimeMillis), CanGroupBy = false });
            this.parameters.Add(new DataParameter<T>(stats => stats.SlowestTimeMillis, stats => true) { Name = nameof(TimeStats.SlowestTimeMillis), CanGroupBy = false });
            this.parameters.Add(new DataParameter<T>(stats => stats.RangeTimeMillis, stats => true) { Name = nameof(TimeStats.RangeTimeMillis), CanGroupBy = false });
            this.parameters.Add(new DataParameter<T>(stats => stats.ExecuterName, stats => true) { Name = nameof(TimeStats.ExecuterName) });
        }
    }
}
