using DataAnalyzer.Services;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class DataConfiguration : VersionedConfiguration, IDataConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public IImportExportKey ImportExportKey { get; set; } = Services.ImportExportKey.Default;

        public string SavedDataFilePath { get; set; } = string.Empty;
    }
}
