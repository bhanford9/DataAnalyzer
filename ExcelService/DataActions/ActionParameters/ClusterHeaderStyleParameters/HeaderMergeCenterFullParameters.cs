namespace ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;

public class HeaderMergeCenterFullParameters : ActionParameters, IHeaderMergeCenterFullParameters
{
    public override string Name => "Merge & Center Cluster Header";

    public override ActionPerformer Performer { get; set; } = ActionPerformer.DataClusterHeader;

    public override ActionCategory Category => ActionCategory.BooleanOperation;
}
