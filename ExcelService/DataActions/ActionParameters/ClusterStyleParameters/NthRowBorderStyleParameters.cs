using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterStyleParameters
{
    public class NthRowBorderStyleParameters : BorderStyleParameters, INthRowBorderStyleParameters
    {
        public override string Name => "Nth Row Border Style";

        public override ActionPerformer Performer { get; set; } = ActionPerformer.DataCluster;

        public int NthRow { get; set; }

        public override ActionCategory Category => ActionCategory.BorderStyle;
    }
}
