using DataAnalyzer.Common.DataObjects;
using System;

namespace DataAnalyzer.Common.DataConfigurations.GroupingConfigurations
{
  public interface IGroupingConfiguration
  {
    void AddCondition(Func<IStats, IComparable> propertyGetter);
    IComparable GetProperty(IStats stats);
  }
}