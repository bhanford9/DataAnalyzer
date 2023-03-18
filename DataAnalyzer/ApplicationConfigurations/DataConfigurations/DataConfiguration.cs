using DataAnalyzer.Services.Enums;
using System;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class DataConfiguration : VersionedConfiguration, IDataConfiguration
    {
        public string Name { get; set; } = string.Empty;

        // TODO --> stat type is no longer a thing. Replace with import/category/flavor
        public StatType StatType { get; set; } = StatType.NotApplicable;

        public ExportType ExportType { get; set; } = ExportType.NotApplicable;

        public string SavedDataFilePath { get; set; } = string.Empty;
    }
}
