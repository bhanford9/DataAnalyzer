using DataAnalyzer.Common.DataObjects;
using System;

namespace DataAnalyzer.Common.DataConfigurations.GroupingConfigurations
{
  public class LinkedGroupingConfiguration : GroupingConfiguration
  {
    public LinkedGroupingConfiguration(Func<IStats, IComparable> propertyGetter)
      : base(propertyGetter)
    {
    }

    public LinkedGroupingConfiguration Next { get; set; } = null;
  }
}
