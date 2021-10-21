using System;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
  [Serializable]
  public class GroupingConfiguration : VersionedConfiguration
  {
    public string GroupName { get; set; } = string.Empty;

    public int GroupLevel { get; set; }

    public string SelectedParameter { get; set; } = string.Empty;
  }
}
