using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions
{
  public interface IDataAction
  {
    string GetName();
    string GetDescription();
    bool IsApplicable(IActionParameters parameters);
    bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message);
    bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message);
    bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message);
    IActionParameters GetDefaultParameters();
  }
}
