using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataConfigurations.GroupingConfigurations
{
    internal interface IGroupingConfiguration
    {
        void AddCondition(Func<IStats, IComparable> propertyGetter);
        IComparable GetProperty(IStats stats);
    }
}