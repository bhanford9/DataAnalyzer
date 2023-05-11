namespace ExcelService.DataActions.ActionParameters.RangeStyleParameters;

public class ColumnBorderStyleParameters : BorderStyleParameters, IColumnBorderStyleParameters
{
    public override string Name => "Column Border";

    public override ActionCategory Category => ActionCategory.ColumnBorderStyle;
}
