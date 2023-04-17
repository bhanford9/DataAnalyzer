using DataAnalyzer.StatConfigurations.GroupingConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class GroupingDataOrganizer<T> : DataOrganizer<GroupingDataConfiguration<T>>, IGroupingDataOrganizer
        where T : ApplicationConfigurations.DataConfigurations.IDataConfiguration
    {
        protected override HeirarchalStats InternalOrganize(GroupingDataConfiguration<T> configuration, ICollection<IStats> data)
        {
            HeirarchalStats heirarchalStats = new();

            ILinkedGroupingConfiguration groupingConfigurations = new LinkedGroupingConfiguration();
            groupingConfigurations.AddCondition(configuration.GroupingConfigurations.First().GetProperty);

            ILinkedGroupingConfiguration temp = groupingConfigurations;
            for (int i = 1; i < configuration.GroupingConfigurations.Count; i++)
            {
                ILinkedGroupingConfiguration linkedGroupConfig = new LinkedGroupingConfiguration();
                linkedGroupConfig.AddCondition(configuration.GroupingConfigurations.ElementAt(i).GetProperty);
                temp.Next = linkedGroupConfig;
                temp = temp.Next;
            }

            this.ApplyNestedGrouping(heirarchalStats, data, groupingConfigurations);

            return heirarchalStats;
        }

        private void ApplyNestedGrouping(
          HeirarchalStats heirarchalStats,
          ICollection<IStats> stats,
          ILinkedGroupingConfiguration groupingConfigurations)
        {
            heirarchalStats.Values.Clear();

            ICollection<IGrouping<IComparable, IStats>> groups =
                stats.GroupBy(x => groupingConfigurations.GetProperty(x)).ToList();

            groups.ToList().ForEach(group =>
            {
                HeirarchalStats stats = new HeirarchalStats { Key = group.Key };
                group.ToList().ForEach(x => stats.Values.Add(x));

                if (groupingConfigurations.Next != null)
                {
                    this.ApplyNestedGrouping(
                        stats,
                        stats.Values.ToList(),
                        groupingConfigurations.Next);
                }

                heirarchalStats.Children.Add(stats);
            });
        }
    }
}
