namespace ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters
{
  public class HeaderMergeCenterFullParameters : ActionParameters
  {
    public override string Name => "Merge & Center Cluster Header";

    public override ActionPerformer Performer { get; set; } = ActionPerformer.DataClusterHeader;
  }
}
