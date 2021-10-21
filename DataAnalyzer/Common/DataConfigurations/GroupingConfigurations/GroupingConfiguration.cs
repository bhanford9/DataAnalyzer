using DataAnalyzer.Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConfigurations.GroupingConfigurations
{
  public class GroupingConfiguration : IGroupingConfiguration
  {
    private readonly ICollection<Func<IStats, IComparable>> propertyGetters = new List<Func<IStats, IComparable>>();

    public GroupingConfiguration(Func<IStats, IComparable> propertyGetter)
    {
      this.propertyGetters.Add(propertyGetter);
    }

    public IComparable GetProperty(IStats stats)
    {
      if (this.propertyGetters.Count == 1)
      {
        return this.propertyGetters.ElementAt(0)(stats);
      }

      string groupByAggregate = string.Empty;
      this.propertyGetters.ToList().ForEach(x => groupByAggregate += x.ToString());
      return groupByAggregate;
    }

    public void AddCondition(Func<IStats, IComparable> propertyGetter)
    {
      this.propertyGetters.Add(propertyGetter);
    }
  }
}
