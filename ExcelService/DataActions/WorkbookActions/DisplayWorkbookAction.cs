using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.WorkbookParameters;
using ExcelService.Workbooks;
using System.Diagnostics;

namespace ExcelService.DataActions.WorkbookActions
{
    public class DisplayWorkbookAction : DataAction
    {
        public override string GetName()
        {
            return "Display Workbook";
        }

        public override string GetDescription()
        {
            return "Opens the workbook after all other actions are complete";
        }

        public override IActionParameters GetDefaultParameters()
        {
            return new DisplayWorkbookParameters();
        }

        public override bool IsApplicable(IActionParameters parameters)
        {
            return this.IsCorrectType(parameters, typeof(DisplayWorkbookParameters)) &&
              parameters.Performer == ActionPerformer.Workbook;
        }

        public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            if (excelEntity is IWorkbook)
            {
                message = string.Empty;
                return true;
            }

            message = "Excel entity must be a Workbook";
            return false;
        }

        public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            DisplayWorkbookParameters param = parameters as DisplayWorkbookParameters;

            if (param.DisplayAfter)
            {
                IWorkbook workbookData = excelEntity as IWorkbook;
                Process.Start(new ProcessStartInfo { FileName = workbookData.FilePath, UseShellExecute = true });
            }

            message = string.Empty;
            return true;
        }

        public override bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            message = string.Empty;
            return true;
        }
    }
}
