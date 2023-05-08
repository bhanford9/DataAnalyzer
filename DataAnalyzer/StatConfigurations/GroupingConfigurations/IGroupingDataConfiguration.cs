using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.StatConfigurations.GroupingConfigurations
{
    internal interface IGroupingDataConfiguration : IStatsConfiguration
    {
        ICollection<IGroupingConfiguration> GroupingConfigurations { get; }
        int GroupingLevels { get; }

        void AddGroupingRule(int level, Func<IStats, IComparable> propertyGetter);
    }
}