using ExcelService.Styles.Borders;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
    public interface IBorderStyleParameters : IActionParameters
    {
        Border AllBorders { get; set; }
        Border Bottom { get; set; }
        IColumnSpecification ColumnSpecification { get; set; }
        Border DiagonalDown { get; set; }
        Border DiagonalUp { get; set; }
        Border Left { get; set; }
        Border Right { get; set; }
        IRowSpecification RowSpecification { get; set; }
        Border Top { get; set; }
    }
}