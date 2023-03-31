using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;
using ExcelParms = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.BackgroundConverters
{
    internal class HeaderBackgroundStyleConverter : BackgroundStyleConverter, IHeaderBackgroundStyleConverter
    {
        public HeaderBackgroundStyleConverter() : base(new HeaderBackgroundStyleParameters()) { }

        public override IActionParameters FromExcel(ExcelParms.IActionParameters input)
        {
            if (input is HeaderBackgroundStyleParameters backgroundParameters)
            {
                return base.FromExcel(backgroundParameters);
            }

            throw new ArgumentException("Invalid type. Expected HeaderBackgroundStyleParameters.");
        }

        public override ExcelParms.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BackgroundParameters backgroundParameters)
            {
                BackgroundStyleParameters backgroundStyleParameters = base.ToExcel(backgroundParameters) as BackgroundStyleParameters;

                return new HeaderBackgroundStyleParameters
                {
                    DoApplyColor = backgroundStyleParameters.DoApplyColor,
                    Color = backgroundStyleParameters.Color,
                    Pattern = backgroundStyleParameters.Pattern,
                    ColumnSpecification = backgroundStyleParameters.ColumnSpecification,
                    RowSpecification = backgroundStyleParameters.RowSpecification,
                };
            }

            throw new ArgumentException("Invalid type. Expected BackgroundParameters.");
        }
    }
}
