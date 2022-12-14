using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.AlignmentConverters
{
    internal class AlignmentStyleConverter : ExcelActionParamConverter
    {
        public AlignmentStyleConverter() : base(new AlignmentStyleParameters()) { }
        protected AlignmentStyleConverter(ExcelService.DataActions.ActionParameters.IActionParameters excelParams) : base(excelParams) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is AlignmentStyleParameters excelAlignmentParams)
            {
                return new AlignmentParameters()
                {
                    HorizontalAlignment = AlignmentConverters2.ToLocalHorizontalAlignment(excelAlignmentParams.Alignments.HorizontalAlignment),
                    VerticalAlignment = AlignmentConverters2.ToLocalVerticalAlignment(excelAlignmentParams.Alignments.VerticalAlignment),
                    Name = excelAlignmentParams.Name
                };
            }

            throw new ArgumentException("Invalid type. Excpected AlignmentStyleParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is AlignmentParameters alignmentParameters)
            {
                return new AlignmentStyleParameters()
                {
                    Alignments = new ExcelService.Styles.Alignments.AlignmentValues()
                    {
                        DoApplyHorizontal = true,
                        DoApplyVertical = true,
                        HorizontalAlignment = AlignmentConverters2.ToExcelHorizontalAlignment(alignmentParameters.HorizontalAlignment),
                        VerticalAlignment = AlignmentConverters2.ToExcelVerticalAlignment(alignmentParameters.VerticalAlignment),
                    },
                };
            }

            throw new ArgumentException("Invalid type. Excpected AlignmentParameters.");
        }
    }
}
