using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterStyleParameters
{
  public class NthRowBorderStyleParameters : BorderStyleParameters
  {
    public override ActionPerformer Performer { get; set; } = ActionPerformer.DataCluster;

    public int NthRow { get; set; }
  }
}
