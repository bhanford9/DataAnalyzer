using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.StatConfigurations.GroupingConfigurations
{
    internal class GroupingConfiguration : IGroupingConfiguration
    {
        private readonly ICollection<Func<IStats, IComparable>> propertyGetters = new List<Func<IStats, IComparable>>();

        public GroupingConfiguration()
        {
        }

        public IComparable GetProperty(IStats stats)
        {
            if (propertyGetters.Count == 1)
            {
                return propertyGetters.ElementAt(0)(stats);
            }

            string groupByAggregate = string.Empty;
            propertyGetters.ToList().ForEach(x => groupByAggregate += x.ToString());
            return groupByAggregate;
        }

        public void AddCondition(Func<IStats, IComparable> propertyGetter) => propertyGetters.Add(propertyGetter);
    }
}
