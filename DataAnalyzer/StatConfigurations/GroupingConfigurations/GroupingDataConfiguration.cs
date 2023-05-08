using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations.GroupingConfigurations
{
    internal abstract class GroupingDataConfiguration<T> : StatsConfiguration<T>, IGroupingDataConfiguration where T : AppDataConfig.IDataConfiguration
    {
        protected ICollection<IGroupingConfiguration> groupingConfigurations = new List<IGroupingConfiguration>();

        public virtual int GroupingLevels { get; protected set; }

        public ICollection<IGroupingConfiguration> GroupingConfigurations => groupingConfigurations;

        public void AddGroupingRule(int level, Func<IStats, IComparable> propertyGetter)
        {
            if (level >= groupingConfigurations.Count)
            {
                GroupingConfiguration config = new();
                config.AddCondition(propertyGetter);
                groupingConfigurations.Add(config);
            }
            else
            {
                groupingConfigurations.ElementAt(level).AddCondition(propertyGetter);
            }
        }
    }
}
