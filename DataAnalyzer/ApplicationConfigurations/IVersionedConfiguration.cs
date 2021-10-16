using System;

namespace DataAnalyzer.ApplicationConfigurations
{
  public interface IVersionedConfiguration
  {
    string VersionUid { get; set; }
    DateTime DateTime { get; set; }
  }
}