using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

// source of truth or currently loaded excel settings
internal class WorkbookModel : BasePropertyChanged, IWorkbookModel
{
    public string FilePath { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public ICollection<IExcelAction> WorkbookActions { get; set; } = new List<IExcelAction>();

    public ICollection<IWorksheetModel> Worksheets { get; set; } = new List<IWorksheetModel>();
}
