using System;
using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
  [Serializable]
  public class DataConfiguration : VersionedConfiguration
  {
    public ICollection<GroupingConfiguration> GroupingConfiguration { get; set; } = new List<GroupingConfiguration>();
  }
}
