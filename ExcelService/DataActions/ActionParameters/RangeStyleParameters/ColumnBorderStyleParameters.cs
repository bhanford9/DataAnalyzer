using ExcelService.Styles.Borders;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
  public class ColumnBorderStyleParameters : ActionParameters
  {
    private Border border = new Border();

    public override string Name => "Column Border";

    public Border Border
    {
      get => this.border;
      set
      {
        this.border = value;
        this.border.DoApply = true;
      }
    }
  }
}
