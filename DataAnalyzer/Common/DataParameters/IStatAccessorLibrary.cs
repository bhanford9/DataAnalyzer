using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters;

internal interface IStatAccessorLibrary
{
    IStatAccessorCollection this[Type statType] { get; }

    TValue GetData<TValue, TStats>(TStats stats, string name)
        where TValue : IComparable
        where TStats : IStats;
    IStatAccessorCollection GetStatAccessors(Type statType);
}