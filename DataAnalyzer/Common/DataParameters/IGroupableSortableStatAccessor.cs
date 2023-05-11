using DataAnalyzer.DataImport.DataObjects;

namespace DataAnalyzer.Common.DataParameters;

internal interface IGroupableSortableStatAccessor<T> : IGroupableStatAccessor<T>, ISortableStatAccessor<T>
     where T : IStats
{
}
