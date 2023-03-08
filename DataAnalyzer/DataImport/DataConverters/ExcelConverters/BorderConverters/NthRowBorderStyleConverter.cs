namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.BorderConverters
{
    //internal sealed class NthRowBorderStyleConverter : BorderStyleConverter
    //{
    //    public NthRowBorderStyleConverter() : base(new NthRowBorderStyleParameters()) { }

    //    public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
    //    {
    //        if (input is NthRowBorderStyleParameters excelBorderParams)
    //        {
    //            BorderParameters borderParameters = base.FromExcel(input) as BorderParameters;
    //            borderParameters.Nth = excelBorderParams.NthRow;
    //            return borderParameters;
    //        }

    //        throw new ArgumentException("Invalid type. Excpected NthRowBorderStyleParameters.");
    //    }

    //    public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
    //    {
    //        if (input is BorderParameters borderParameters)
    //        {
    //            BorderStyleParameters borderStyleParams = base.ToExcel(input) as BorderStyleParameters;
    //            return new NthRowBorderStyleParameters()
    //            {
    //                Left = borderStyleParams.Left,
    //                Top = borderStyleParams.Top,
    //                Right = borderStyleParams.Right,
    //                Bottom = borderStyleParams.Bottom,
    //                DiagonalUp = borderStyleParams.DiagonalUp,
    //                DiagonalDown = borderStyleParams.DiagonalDown,
    //                AllBorders = borderStyleParams.AllBorders,
    //                NthRow = borderParameters.Nth
    //            };
    //        }

    //        throw new ArgumentException("Invalid type. Excpected BorderParameters.");
    //    }
    //}
}
