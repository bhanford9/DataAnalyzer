using ExcelService.Styles.Colors;
using ExcelService.Styles.Patterns;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters;

public interface IBackgroundStyleParameters : IActionParameters
{
    ColorValue Color { get; set; }
    IColumnSpecification ColumnSpecification { get; set; }
    bool DoApplyColor { get; set; }
    FillPatternValue Pattern { get; set; }
    IRowSpecification RowSpecification { get; set; }
}