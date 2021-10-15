using DataAnalyzer.Common.DataConfigurations.GroupingConfigurations;
using DataAnalyzer.Common.DataObjects;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataConfigurations
{
  public interface IDataConfiguration
  {
    int GroupingLevels { get; }

    ICollection<IGroupingConfiguration> GroupingConfigurations { get; }

    void AddGroupingRule(int level, Func<IStats, IComparable> propertyGetter);
  }
}
