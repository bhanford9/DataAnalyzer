using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class LastSavedConfiguration
    {
        public IImportExportKey ImportExportKey { get; set; } = Services.ImportExportKey.Default;

        public string FilePath { get; set; } = string.Empty;
    }
}
