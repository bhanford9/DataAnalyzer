using System;

namespace DataAnalyzer.ApplicationConfigurations
{
  public class VersionedConfiguration : IVersionedConfiguration
  {
    public string VersionUid { get; set; } = string.Empty;

    public DateTime DateTime { get; set; } = DateTime.Now;
  }
}
