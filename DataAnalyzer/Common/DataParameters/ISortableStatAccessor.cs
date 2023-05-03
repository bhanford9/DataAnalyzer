using DataAnalyzer.DataImport.DataObjects;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface ISortableStatAccessor<T> : IStatAccessor<T> where T : IStats
    {
        bool CanSortBy { get; set; }
    }
}