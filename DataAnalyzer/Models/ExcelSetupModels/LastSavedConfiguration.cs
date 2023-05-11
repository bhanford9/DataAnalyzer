using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels;

internal class LastSavedConfiguration : ILastSavedConfiguration
{
    public IImportExecutionKey ImportExecutionKey { get; set; } = Services.ImportExecutionKey.Default;

    public string FilePath { get; set; } = string.Empty;
}
