using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.Utilities;

namespace ExcelService.DataActions.SharedActions;

public class BackgroundStyleAction : DataAction, IBackgroundStyleAction
{

    public override string GetName()
    {
        return "Background Style";
    }

    public override string GetDescription()
    {
        return "Sets the color and style of the background fill for a Cell, Row or Data Cluster";
    }

    public override IActionParameters GetDefaultParameters()
    {
        return new BackgroundStyleParameters();
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

        ColumnRowSpecification columnRowSpec = new ColumnRowSpecification
        {
            RowSpecification = backgroundColorParameters.RowSpecification,
            ColumnSpecification = backgroundColorParameters.ColumnSpecification,
        };

        if (backgroundColorParameters.DoApplyColor)
        {
            RowAndColumnSpecHandler.Handle(
                columnRowSpec,
                range,
                x => x.Style.Fill.BackgroundColor = backgroundColorParameters.Color.ToXlColorFromLocal());
        }

        if (backgroundColorParameters.Pattern.DoApply)
        {
            RowAndColumnSpecHandler.Handle(
                columnRowSpec,
                range,
                x =>
                {
                    x.Style.Fill.PatternType = backgroundColorParameters.Pattern.ToXlFromLocal();
                    x.Style.Fill.PatternColor = backgroundColorParameters.Pattern.Color.ToXlColorFromLocal();
                });
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
