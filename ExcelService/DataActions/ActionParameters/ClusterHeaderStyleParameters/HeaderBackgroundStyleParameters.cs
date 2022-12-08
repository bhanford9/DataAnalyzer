using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters
{
    public class HeaderBackgroundStyleParameters : BackgroundStyleParameters
    {
        public override ActionPerformer Performer { get; set; } = ActionPerformer.DataClusterHeader;

        public override ActionCategory Category => ActionCategory.BackgroundStyle;
    }
}
