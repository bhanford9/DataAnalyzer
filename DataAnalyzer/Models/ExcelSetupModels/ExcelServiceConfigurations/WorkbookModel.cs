using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
  // source of truth or currently loaded excel settings
  public class WorkbookModel : BasePropertyChanged
  {
    public string FilePath { get; set; } = string.Empty;

    public ICollection<ExcelAction> WorkbookActions { get; set; } = new List<ExcelAction>();

    public ICollection<WorksheetModel> Worksheets { get; set; } = new List<WorksheetModel>();
  }
}
