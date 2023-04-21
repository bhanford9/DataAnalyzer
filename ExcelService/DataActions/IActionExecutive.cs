using ClosedXML.Excel;
using ExcelService.ReturnMessages;

namespace ExcelService.DataActions
{
    public interface IActionExecutive
    {
        ActionStatus PerformActions(IXLWorkbook workbook, IExcelEntity excelEntity);
        void PerformActions(IXLWorkbook workbook, IExcelEntity excelEntity, Action<ActionStatus> onFailure, Action<ActionStatus> onSuccess = null);
        bool PerformActions(IXLWorkbook workbook, IExcelEntity excelEntity, out ActionStatus result);
    }
}