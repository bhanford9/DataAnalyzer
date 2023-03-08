using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface IDataParameter
    {
        bool CanGroupBy { get; set; }
        bool CanSortBy { get; set; }
        string Name { get; set; }
        Func<IStats, IComparable> StatAccessor { get; }
    }
}