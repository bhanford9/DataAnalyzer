using DataAnalyzer.Common.DataConverters.ExcelConverters;
using DataAnalyzer.Common.Mvvm;
using ExcelService.DataActions;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelSetupModel : BasePropertyChanged
  {
    public ExcelSetupModel()
    {
      ActionLibrary actionLibrary = new ActionLibrary();

      this.WorkbookActions = actionLibrary.GetWorkbookActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList();

      this.WorksheetActions = actionLibrary.GetWorksheetActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList();

      this.DataClusterActions = actionLibrary.GetDataClusterActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList();

      this.RowActions = actionLibrary.GetRowActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList();

      this.CellActions = actionLibrary.GetCellActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList();
    }

    public ICollection<ExcelAction> WorkbookActions { get; }

    public ICollection<ExcelAction> WorksheetActions { get; }

    public ICollection<ExcelAction> DataClusterActions { get; }

    public ICollection<ExcelAction> RowActions { get; }

    public ICollection<ExcelAction> CellActions { get; }
  }
}
