using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class DataConfiguration : VersionedConfiguration, IDataConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public ImportExportKey ImportExportKey { get; set; } = ImportExportKey.Default;

        public ExportType ExportType { get; set; } = ExportType.NotApplicable;

        public string SavedDataFilePath { get; set; } = string.Empty;
    }
}
