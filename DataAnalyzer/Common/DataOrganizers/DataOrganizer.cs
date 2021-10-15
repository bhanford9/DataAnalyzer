using DataAnalyzer.Common.DataConfigurations;
using DataAnalyzer.Common.DataConfigurations.GroupingConfigurations;
using DataAnalyzer.Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataOrganizers
{
  public class DataOrganizer : IDataOrganizer
  {
    public void Organize(IDataConfiguration configuration, ICollection<IStats> data)
    {
      HeirarchalStats heirarchalStats = new HeirarchalStats();

      LinkedGroupingConfiguration groupingConfigurations = 
        new LinkedGroupingConfiguration(configuration.GroupingConfigurations.First().GetProperty);

      LinkedGroupingConfiguration temp = groupingConfigurations;
      for (int i = 1; i < configuration.GroupingConfigurations.Count; i++)
      {
        temp.Next = new LinkedGroupingConfiguration(configuration.GroupingConfigurations.ElementAt(i).GetProperty);
        temp = temp.Next;
      }

      this.ApplyNestedGrouping(heirarchalStats, data, groupingConfigurations);
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
          HeirarchalStats stats = new HeirarchalStats() { Key = group.Key };
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
