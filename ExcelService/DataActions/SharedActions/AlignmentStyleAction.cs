using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.SharedActions
{
  public class AlignmentStyleAction : DataAction
  {
    public override string GetName()
    {
      return "Alignments";
    }

    public override string GetDescription()
    {
      return "Applies the horizontal and vertical alignments for a Cell, Row or DataCluster";
    }

    public override IActionParameters GetDefaultParameters()
    {
      return new AlignmentStyleParameters();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return this.IsCorrectType(parameters, typeof(AlignmentStyleParameters)) &&
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
      AlignmentStyleParameters alignmentStyleParameters = parameters as AlignmentStyleParameters;
      ICellRange cellRange = excelEntity as ICellRange;
      IXLWorksheet worksheet = workbook.Worksheets.Worksheet(alignmentStyleParameters.WorksheetName);

      IXLRange range = worksheet.Range(
        cellRange.StartRowNumber,
        cellRange.StartColNumber,
        cellRange.EndRowNumber,
        cellRange.EndColNumber);

      if (alignmentStyleParameters.Alignments.DoApplyHorizontal)
      {
        range.Style.Alignment.SetHorizontal(alignmentStyleParameters.Alignments.ToXlHorizontalAlignment());
      }

      if (alignmentStyleParameters.Alignments.DoApplyVertical)
      {
        range.Style.Alignment.SetVertical(alignmentStyleParameters.Alignments.ToXlVerticalAlignment());
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
