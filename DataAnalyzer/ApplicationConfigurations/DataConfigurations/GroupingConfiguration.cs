using DataAnalyzer.Common.DataObjects;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
  [Serializable]
  public class GroupingConfiguration : VersionedConfiguration
  {
    public string GroupName { get; set; } = string.Empty;

    public int GroupLevel { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public Func<IStats, IComparable> Accessor { get; set; }
  }
}
