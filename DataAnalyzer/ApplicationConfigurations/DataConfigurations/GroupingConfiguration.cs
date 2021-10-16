using DataAnalyzer.Common.DataObjects;
using System;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
  [Serializable]
  public class GroupingConfiguration : VersionedConfiguration
  {
    public string GroupName { get; set; } = string.Empty;

    public int GroupLevel { get; set; }

    public Func<IStats, IComparable> Accessor { get; set; }
  }
}
