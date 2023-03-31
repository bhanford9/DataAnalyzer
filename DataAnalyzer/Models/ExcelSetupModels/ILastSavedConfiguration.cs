using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal interface ILastSavedConfiguration
    {
        string FilePath { get; set; }
        IImportExportKey ImportExportKey { get; set; }
    }
}