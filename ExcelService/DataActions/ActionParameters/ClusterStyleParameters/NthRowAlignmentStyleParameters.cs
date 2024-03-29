﻿using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterStyleParameters
{
    public class NthRowAlignmentStyleParameters : AlignmentStyleParameters
    {
        public override string Name => "Nth Row Alignment Style";

        public override ActionPerformer Performer { get; set; } = ActionPerformer.DataCluster;

        public int NthRow { get; set; }

        public override ActionCategory Category => ActionCategory.AlignmentStyle;
    }
}
