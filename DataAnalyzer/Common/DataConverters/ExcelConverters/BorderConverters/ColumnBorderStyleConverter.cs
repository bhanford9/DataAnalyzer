﻿using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.BorderConverters
{
    // I don't think this is necessary anymore
    internal class ColumnBorderStyleConverter : BorderStyleConverter
    {
        public ColumnBorderStyleConverter() : base(new ColumnBorderStyleParameters()) { }
    }
}
