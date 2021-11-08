using ExcelService.Styles.Borders;

namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters
{
  public class BorderStyleParameters : ActionParameters
  {
    private Border left = new Border();
    private Border top = new Border();
    private Border right = new Border();
    private Border bottom = new Border();
    private Border diagonalUp = new Border();
    private Border diagonalDown = new Border();
    private Border allBorders = new Border();

    public Border Left
    {
      get => this.left;
      set
      {
        this.left = value;
        this.left.DoApply = true;
      }
    }

    public Border Top
    {
      get => this.top;
      set
      {
        this.top = value;
        this.top.DoApply = true;
      }
    }

    public Border Right
    {
      get => this.right;
      set
      {
        this.right = value;
        this.right.DoApply = true;
      }
    }

    public Border Bottom
    {
      get => this.bottom;
      set
      {
        this.bottom = value;
        this.bottom.DoApply = true;
      }
    }

    public Border DiagonalUp
    {
      get => this.diagonalUp;
      set
      {
        this.diagonalUp = value;
        this.diagonalUp.DoApply = true;
      }
    }

    public Border DiagonalDown
    {
      get => this.diagonalDown;
      set
      {
        this.diagonalDown = value;
        this.diagonalDown.DoApply = true;
      }
    }

    public Border AllBorders
    {
      get => this.allBorders;
      set
      {
        this.allBorders = value;
        this.allBorders.DoApply = true;
      }
    }

    public override string Name => "Border Styling";

    public override ActionPerformer Performer { get; set; }
  }
}
