using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class LastSavedConfiguration
    {
        public ImportExportKey ImportExportKey { get; set; } = ImportExportKey.Default;

        public string FilePath { get; set; } = string.Empty;
    }
}
