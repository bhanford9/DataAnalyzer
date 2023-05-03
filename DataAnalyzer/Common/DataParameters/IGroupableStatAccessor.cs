using DataAnalyzer.DataImport.DataObjects;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface IGroupableStatAccessor<in T> : IStatAccessor<T> where T : IStats
    {
        bool CanGroupBy { get; set; }
    }
}