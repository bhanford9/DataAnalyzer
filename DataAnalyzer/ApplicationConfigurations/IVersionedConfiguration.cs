using System;

namespace DataAnalyzer.ApplicationConfigurations
{
    internal interface IVersionedConfiguration
    {
        string VersionUid { get; set; }
        DateTime DateTime { get; set; }
    }
}