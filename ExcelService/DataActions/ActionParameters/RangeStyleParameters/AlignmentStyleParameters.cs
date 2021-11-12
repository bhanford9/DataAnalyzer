using ExcelService.Styles.Alignments;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
  public class AlignmentStyleParameters : ActionParameters
  {
    public override string Name => "Alignments";

    public AlignmentValues Alignments { get; set; } = new AlignmentValues();

    public override ActionCategory Category => ActionCategory.AlignmentStyle;
  }
}
