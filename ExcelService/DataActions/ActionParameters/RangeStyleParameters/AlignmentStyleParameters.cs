using ExcelService.Styles.Alignments;
using ExcelService.Utilities;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters;

public class AlignmentStyleParameters : ActionParameters, IAlignmentStyleParameters
{
    public override string Name => "Alignments";

    public AlignmentValues Alignments { get; set; } = new AlignmentValues();

    public override ActionCategory Category => ActionCategory.AlignmentStyle;

    public IColumnSpecification ColumnSpecification { get; set; } = new ColumnSpecification();

    public IRowSpecification RowSpecification { get; set; } = new RowSpecification();
}
