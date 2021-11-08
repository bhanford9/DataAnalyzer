using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.SharedActions
{
  public class BackgroundStyleAction : DataAction
  {

    public override string GetName()
    {
      return "Background Style";
    }

    public override string GetDescription()
    {
      return "Sets the color and style of the background fill for a Cell, Row or Data Cluster";
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return this.IsCorrectType(parameters, typeof(BackgroundStyleParameters)) &&
        (parameters.Performer == ActionPerformer.Cell ||
        parameters.Performer == ActionPerformer.Row ||
        parameters.Performer == ActionPerformer.DataCluster);
    }

    public override bool CanExecute(IExcelEntity excelEntity, IActionParameters parameters, out string message)
    {
      if (excelEntity is ICellRange)
      {
        message = string.Empty;
        return true;
      }

      message = "Excel entity must be a Cell, Row or DataCluster";
      return false;
    }

    public override bool Execute(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
    {
      BackgroundStyleParameters backgroundColorParameters = parameters as BackgroundStyleParameters;
      ICellRange cellRange = excelEntity as ICellRange;
      IXLWorksheet worksheet = workbook.Worksheets.Worksheet(backgroundColorParameters.WorksheetName);

      IXLRange range = worksheet.Range(
        cellRange.StartRowNumber,
        cellRange.StartColNumber,
        cellRange.EndRowNumber,
        cellRange.EndColNumber);

      if (backgroundColorParameters.DoApplyColor)
      {
        range.Style.Fill.BackgroundColor = backgroundColorParameters.Color.ToXlColorFromLocal();
      }

      if (backgroundColorParameters.Pattern.DoApply)
      {
        range.Style.Fill.PatternType = backgroundColorParameters.Pattern.ToXlFromLocal();
        range.Style.Fill.PatternColor = backgroundColorParameters.Pattern.Color.ToXlColorFromLocal();
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
