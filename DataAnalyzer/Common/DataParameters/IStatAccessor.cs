using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters;

internal interface IStatAccessor<in T> where T : IStats
{
    string Name { get; set; }
    IComparable GetValue(T stats);
}