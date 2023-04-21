using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface IDataParameter<in T> where T : IStats
    {
        bool CanGroupBy { get; set; }
        bool CanSortBy { get; set; }
        string Name { get; set; }
        Func<T, IComparable> StatAccessor { get; }
    }
}