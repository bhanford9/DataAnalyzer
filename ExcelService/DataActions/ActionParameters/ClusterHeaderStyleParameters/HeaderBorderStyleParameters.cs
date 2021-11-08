using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters
{
  public class HeaderBorderStyleParameters : BorderStyleParameters
  {
    public override ActionPerformer Performer { get; set; } = ActionPerformer.DataClusterHeader;
  }
}
