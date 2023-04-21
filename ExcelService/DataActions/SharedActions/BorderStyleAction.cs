using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.Utilities;

namespace ExcelService.DataActions.SharedActions
{
    public class BorderStyleAction : DataAction, IBorderStyleAction
    {

        public override string GetName()
        {
            return "Border Style";
        }

        public override string GetDescription()
        {
            return "Sets the color and style of the border(s) for a Cell, Row or Data Cluster";
        }

        public override IActionParameters GetDefaultParameters()
        {
            return new BorderStyleParameters();
        }

        public override bool IsApplicable(IActionParameters parameters)
        {
            return this.IsCorrectType(parameters, typeof(BorderStyleParameters)) &&
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
            BorderStyleParameters borderStyleParameters = parameters as BorderStyleParameters;
            ICellRange cellRange = excelEntity as ICellRange;
            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(borderStyleParameters.WorksheetName);

            IXLRange range = worksheet.Range(
              cellRange.StartRowNumber,
              cellRange.StartColNumber,
              cellRange.EndRowNumber,
              cellRange.EndColNumber);

            ApplyBorder(range, borderStyleParameters);

            message = string.Empty;
            return true;
        }

        public override bool PostExecution(IXLWorkbook workbook, IExcelEntity excelEntity, IActionParameters parameters, out string message)
        {
            message = string.Empty;
            return true;
        }

        protected void ApplyBorder(IXLRangeBase range, BorderStyleParameters borderStyleParameters)
        {
            ColumnRowSpecification columnRowSpec = new ColumnRowSpecification
            {
                RowSpecification = borderStyleParameters.RowSpecification,
                ColumnSpecification = borderStyleParameters.ColumnSpecification,
            };

            if (borderStyleParameters.AllBorders.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.LeftBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
                        x.Style.Border.LeftBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
                        x.Style.Border.TopBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
                        x.Style.Border.TopBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
                        x.Style.Border.RightBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
                        x.Style.Border.RightBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
                        x.Style.Border.BottomBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
                        x.Style.Border.BottomBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
                    });
            }

            if (borderStyleParameters.Left.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.LeftBorder = borderStyleParameters.Left.ToXlBorderStyle();
                        x.Style.Border.LeftBorderColor = borderStyleParameters.Left.Color.ToXlColorFromLocal();
                    });
            }

            if (borderStyleParameters.Top.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.TopBorder = borderStyleParameters.Top.ToXlBorderStyle();
                        x.Style.Border.TopBorderColor = borderStyleParameters.Top.Color.ToXlColorFromLocal();
                    });
            }

            if (borderStyleParameters.Right.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.RightBorder = borderStyleParameters.Right.ToXlBorderStyle();
                        x.Style.Border.RightBorderColor = borderStyleParameters.Right.Color.ToXlColorFromLocal();
                    });
            }

            if (borderStyleParameters.Bottom.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.BottomBorder = borderStyleParameters.Bottom.ToXlBorderStyle();
                        x.Style.Border.BottomBorderColor = borderStyleParameters.Bottom.Color.ToXlColorFromLocal();
                    });
            }

            if (borderStyleParameters.DiagonalUp.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.DiagonalBorder = borderStyleParameters.DiagonalUp.ToXlBorderStyle();
                        x.Style.Border.DiagonalBorderColor = borderStyleParameters.DiagonalUp.Color.ToXlColorFromLocal();
                        x.Style.Border.DiagonalUp = true;
                    });
            }

            if (borderStyleParameters.DiagonalDown.DoApply)
            {
                RowAndColumnSpecHandler.Handle(
                    columnRowSpec,
                    range.AsRange(),
                    x =>
                    {
                        x.Style.Border.DiagonalBorder = borderStyleParameters.DiagonalDown.ToXlBorderStyle();
                        x.Style.Border.DiagonalBorderColor = borderStyleParameters.DiagonalDown.Color.ToXlColorFromLocal();
                        x.Style.Border.DiagonalDown = true;
                    });
            }
        }

        //protected void ApplyBorder(IXLRange range, BorderStyleParameters borderStyleParameters)
        //{
        //    if (borderStyleParameters.AllBorders.DoApply)
        //    {
        //        range.FirstColumn().Style.Border.LeftBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
        //        range.FirstColumn().Style.Border.LeftBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
        //        range.FirstRow().Style.Border.TopBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
        //        range.FirstRow().Style.Border.TopBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
        //        range.LastColumn().Style.Border.RightBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
        //        range.LastColumn().Style.Border.RightBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
        //        range.LastRow().Style.Border.BottomBorder = borderStyleParameters.AllBorders.ToXlBorderStyle();
        //        range.LastRow().Style.Border.BottomBorderColor = borderStyleParameters.AllBorders.Color.ToXlColorFromLocal();
        //    }

        //    if (borderStyleParameters.Left.DoApply)
        //    {
        //        range.FirstColumn().Style.Border.LeftBorder = borderStyleParameters.Left.ToXlBorderStyle();
        //        range.FirstColumn().Style.Border.LeftBorderColor = borderStyleParameters.Left.Color.ToXlColorFromLocal();
        //    }

        //    if (borderStyleParameters.Top.DoApply)
        //    {
        //        range.FirstRow().Style.Border.TopBorder = borderStyleParameters.Top.ToXlBorderStyle();
        //        range.FirstRow().Style.Border.TopBorderColor = borderStyleParameters.Top.Color.ToXlColorFromLocal();
        //    }

        //    if (borderStyleParameters.Right.DoApply)
        //    {
        //        range.LastColumn().Style.Border.RightBorder = borderStyleParameters.Right.ToXlBorderStyle();
        //        range.LastColumn().Style.Border.RightBorderColor = borderStyleParameters.Right.Color.ToXlColorFromLocal();
        //    }

        //    if (borderStyleParameters.Bottom.DoApply)
        //    {
        //        range.LastRow().Style.Border.BottomBorder = borderStyleParameters.Bottom.ToXlBorderStyle();
        //        range.LastRow().Style.Border.BottomBorderColor = borderStyleParameters.Bottom.Color.ToXlColorFromLocal();
        //    }

        //    if (borderStyleParameters.DiagonalUp.DoApply)
        //    {
        //        range.Style.Border.DiagonalBorder = borderStyleParameters.DiagonalUp.ToXlBorderStyle();
        //        range.Style.Border.DiagonalBorderColor = borderStyleParameters.DiagonalUp.Color.ToXlColorFromLocal();
        //        range.Style.Border.DiagonalUp = true;
        //    }

        //    if (borderStyleParameters.DiagonalDown.DoApply)
        //    {
        //        range.Style.Border.DiagonalBorder = borderStyleParameters.DiagonalDown.ToXlBorderStyle();
        //        range.Style.Border.DiagonalBorderColor = borderStyleParameters.DiagonalDown.Color.ToXlColorFromLocal();
        //        range.Style.Border.DiagonalDown = true;
        //    }
        //}
    }
}
