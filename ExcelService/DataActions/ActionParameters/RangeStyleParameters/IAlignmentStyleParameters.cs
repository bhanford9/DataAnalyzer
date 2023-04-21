using ExcelService.Styles.Alignments;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
    public interface IAlignmentStyleParameters : IActionParameters
    {
        AlignmentValues Alignments { get; set; }
        IColumnSpecification ColumnSpecification { get; set; }
        IRowSpecification RowSpecification { get; set; }
    }
}