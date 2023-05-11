using DataAnalyzer.DataImport.DataObjects.TimeStats;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters;

internal abstract class TimeParameters<T> : StatAccessorCollection<T>, ITimeParameters
    where T : ITimeStats
{
    internal override void AddStatAccessor()
    {
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.Iterations, stats => true) { Name = nameof(TimeStats.Iterations) });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.ContainerSize, stats => true) { Name = nameof(TimeStats.ContainerSize) });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.TotalTimeMillis, stats => true) { Name = nameof(TimeStats.TotalTimeMillis), CanGroupBy = false });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.AverageTimeMillis, stats => true) { Name = nameof(TimeStats.AverageTimeMillis), CanGroupBy = false });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.FastestTimeMillis, stats => true) { Name = nameof(TimeStats.FastestTimeMillis), CanGroupBy = false });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.SlowestTimeMillis, stats => true) { Name = nameof(TimeStats.SlowestTimeMillis), CanGroupBy = false });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.RangeTimeMillis, stats => true) { Name = nameof(TimeStats.RangeTimeMillis), CanGroupBy = false });
        this.statAccessors.Add(new GroupableSortableStatAccessor<T>(stats => stats.ExecuterName, stats => true) { Name = nameof(TimeStats.ExecuterName) });
    }

    public IReadOnlyCollection<IStatAccessor<T>> GetGroupableParameters() =>
        this.statAccessors
            .OfType<IGroupableSortableStatAccessor<T>>()
            .Where(x => x.CanGroupBy)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<string> GetGroupableParameterNames() =>
        this.statAccessors
            .OfType<IGroupableSortableStatAccessor<T>>()
            .Where(x => x.CanGroupBy)
            .Select(x => x.Name)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<IStatAccessor<T>> GetSortableParameters() =>
        this.statAccessors
            .OfType<IGroupableSortableStatAccessor<T>>()
            .Where(x => x.CanSortBy)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<string> GetSortableParameterNames() =>
        this.statAccessors
            .OfType<IGroupableSortableStatAccessor<T>>()
            .Where(x => x.CanSortBy)
            .Select(x => x.Name)
            .ToList()
            .AsReadOnly();

}
