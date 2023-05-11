using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters;

internal class SortableStatAccessor<T> : StatAccessor<T>, ISortableStatAccessor<T>
    where T : IStats
{
    public SortableStatAccessor(Func<T, IComparable> extractor, Func<T, bool> validator)
        : base(extractor, validator)
    {
    }

    public bool CanSortBy { get; set; }
}
