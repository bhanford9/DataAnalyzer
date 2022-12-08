using DataAnalyzer.Services;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    [Serializable]
    internal class DataConfiguration : VersionedConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public StatType StatType { get; set; } = StatType.NotApplicable;

        public ExportType ExportType { get; set; } = ExportType.NotApplicable;

        public ICollection<GroupingConfiguration> GroupingConfiguration { get; set; } = new List<GroupingConfiguration>();

        public string SavedDataFilePath { get; set; } = string.Empty;
    }
}
