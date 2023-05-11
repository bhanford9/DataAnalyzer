using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.StatConfigurations.GroupingConfigurations;

internal interface IGroupingConfiguration
{
    void AddCondition(Func<IStats, IComparable> propertyGetter);
    IComparable GetProperty(IStats stats);
}