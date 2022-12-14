using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.BackgroundConverters
{
    internal class HeaderBackgroundStyleConverter : BackgroundStyleConverter
    {
        public HeaderBackgroundStyleConverter() : base(new HeaderBackgroundStyleParameters()) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is HeaderBackgroundStyleParameters backgroundParameters)
            {
                return base.FromExcel(backgroundParameters);
            }

            throw new ArgumentException("Invalid type. Excpected HeaderBackgroundStyleParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BackgroundParameters backgroundParameters)
            {
                BackgroundStyleParameters backgroundStyleParameters = base.ToExcel(backgroundParameters) as BackgroundStyleParameters;

                return new HeaderBackgroundStyleParameters()
                {
                    DoApplyColor = backgroundStyleParameters.DoApplyColor,
                    Color = backgroundStyleParameters.Color,
                    Pattern = backgroundStyleParameters.Pattern,
                };
            }

            throw new ArgumentException("Invalid type. Excpected BackgroundParameters.");
        }
    }
}
