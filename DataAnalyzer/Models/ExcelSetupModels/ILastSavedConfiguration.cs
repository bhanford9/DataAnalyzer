using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal interface ILastSavedConfiguration
    {
        string FilePath { get; set; }
        IImportExecutionKey ImportExecutionKey { get; set; }
    }
}