using ExcelService.Styles.Colors;
using ExcelService.Styles.Patterns;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
  public class BackgroundStyleParameters : ActionParameters
  {
    private ColorValue color = new ColorValue(Styles.Colors.Color.Transparent);
    private FillPatternValue pattern = new FillPatternValue();

    public override string Name => "Background Color";

    public bool DoApplyColor { get; set; } = false;

    public ColorValue Color
    {
      get => this.color;
      set
      {
        this.color = value;
        this.DoApplyColor = true;
      }
    }

    public FillPatternValue Pattern
    {
      get => this.pattern;
      set
      {
        this.pattern = value;
        this.pattern.DoApply = true;
      }
    }
  }
}
