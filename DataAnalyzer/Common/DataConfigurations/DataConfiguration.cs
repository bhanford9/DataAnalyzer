using DataAnalyzer.Common.DataConfigurations.GroupingConfigurations;
using DataAnalyzer.Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConfigurations
{
    internal abstract class DataConfiguration : IDataConfiguration
    {
        protected ICollection<IGroupingConfiguration> groupingConfigurations = new List<IGroupingConfiguration>();

        public abstract int GroupingLevels { get; protected set; }

        public ICollection<IGroupingConfiguration> GroupingConfigurations => this.groupingConfigurations;

        public void AddGroupingRule(int level, Func<IStats, IComparable> propertyGetter)
        {
            if (level >= this.groupingConfigurations.Count)
            {
                this.groupingConfigurations.Add(new GroupingConfiguration(propertyGetter));
            }
            else
            {
                this.groupingConfigurations.ElementAt(level).AddCondition(propertyGetter);
            }
        }
    }
}
