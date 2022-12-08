using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.DataClusters;
using ExcelService.Rows;

namespace ExcelService.DataActions.SharedActions
{
    public class ColumnBorderStyleAction : DataAction
    {

        public override string GetName()
        {
            return "Column Border";
        }

        public override string GetDescription()
        {
            return "Styles the column border BETWEEN cells for each column of a Row or Data Cluster";
        }

        public override IActionParameters GetDefaultParameters()
        {
            return new ColumnBorderStyleParameters();
        }

        public override bool IsApplicable(IActionParameters parameters)
        {
            return this.IsCorrectType(parameters, typeof(ColumnBorderStyleParameters)) &&
              (parameters.Performer == ActionPerformer.Row ||
              parameters.Performer == ActionPerformer.DataCluster);
        }

        public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            if (excelEntity is IRow || excelEntity is IDataCluster)
            {
                message = string.Empty;
                return true;
            }

            message = "Excel entity must be a Row or DataCluster";
            return false;
        }

        public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            ColumnBorderStyleParameters borderStyleParameters = parameters as ColumnBorderStyleParameters;
            ICellRange cellRange = excelEntity as ICellRange;
            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(borderStyleParameters.WorksheetName);

            IXLRange range = worksheet.Range(
              cellRange.StartRowNumber,
              cellRange.StartColNumber,
              cellRange.EndRowNumber,
              cellRange.EndColNumber);

            if (borderStyleParameters.Border.DoApply)
            {
                for (int i = 1; i < range.ColumnCount(); i++)
                {
                    range.Column(i).Style.Border.RightBorder = borderStyleParameters.Border.ToXlBorderStyle();
                    range.Column(i).Style.Border.RightBorderColor = borderStyleParameters.Border.Color.ToXlColorFromLocal();
                }
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
