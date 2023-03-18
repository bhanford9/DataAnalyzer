using DataAnalyzer.StatConfigurations.GroupingConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class GroupingDataOrganizer<T> : DataOrganizer<GroupingDataConfiguration<T>>
        where T : ApplicationConfigurations.DataConfigurations.IDataConfiguration
    {
        protected override HeirarchalStats InternalOrganize(GroupingDataConfiguration<T> configuration, ICollection<IStats> data)
        {
            HeirarchalStats heirarchalStats = new();

            LinkedGroupingConfiguration groupingConfigurations = new (configuration.GroupingConfigurations.First().GetProperty);

            LinkedGroupingConfiguration temp = groupingConfigurations;
            for (int i = 1; i < configuration.GroupingConfigurations.Count; i++)
            {
                temp.Next = new LinkedGroupingConfiguration(configuration.GroupingConfigurations.ElementAt(i).GetProperty);
                temp = temp.Next;
            }

            this.ApplyNestedGrouping(heirarchalStats, data, groupingConfigurations);

            return heirarchalStats;
        }

        private void ApplyNestedGrouping(
          HeirarchalStats heirarchalStats,
          ICollection<IStats> stats,
          LinkedGroupingConfiguration groupingConfigurations)
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
