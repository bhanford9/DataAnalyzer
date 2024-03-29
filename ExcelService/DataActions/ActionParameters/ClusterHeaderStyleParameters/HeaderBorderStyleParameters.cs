﻿using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters
{
    public class HeaderBorderStyleParameters : BorderStyleParameters
    {
        public override string Name => "Header Border Style";

        public override ActionPerformer Performer { get; set; } = ActionPerformer.DataClusterHeader;

        public override ActionCategory Category => ActionCategory.BorderStyle;
    }
}
