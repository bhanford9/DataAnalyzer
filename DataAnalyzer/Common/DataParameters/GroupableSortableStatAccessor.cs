using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters;

internal class GroupableSortableStatAccessor<T> : GroupableStatAccessor<T>, IGroupableSortableStatAccessor<T>
    where T : IStats
{
    public GroupableSortableStatAccessor(Func<T, IComparable> extractor, Func<T, bool> validator) : base(extractor, validator)
    {
    }

    public bool CanSortBy { get; set; }
}
