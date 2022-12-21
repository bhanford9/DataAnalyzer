using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;
using DataAnalyzer.Common.DataConverters.ExcelConverters.UtilityConverters;

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
                return new AlignmentParameters
                {
                    HorizontalAlignment = AlignmentTypeConverters.ToLocalHorizontalAlignment(excelAlignmentParams.Alignments.HorizontalAlignment),
                    VerticalAlignment = AlignmentTypeConverters.ToLocalVerticalAlignment(excelAlignmentParams.Alignments.VerticalAlignment),
                    ColumnSpecification = ColumnSpecificationConverter.ToLocalColumnSpecification(excelAlignmentParams.ColumnSpecification),
                    RowSpecification = RowSpecificationConverter.ToLocalRowSpecification(excelAlignmentParams.RowSpecification),
                    Name = excelAlignmentParams.Name
                };
            }

            throw new ArgumentException("Invalid type. Expected AlignmentStyleParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is AlignmentParameters alignmentParameters)
            {
                return new AlignmentStyleParameters
                {
                    Alignments = new ExcelService.Styles.Alignments.AlignmentValues
                    {
                        DoApplyHorizontal = true,
                        DoApplyVertical = true,
                        HorizontalAlignment = AlignmentTypeConverters.ToExcelHorizontalAlignment(alignmentParameters.HorizontalAlignment),
                        VerticalAlignment = AlignmentTypeConverters.ToExcelVerticalAlignment(alignmentParameters.VerticalAlignment),
                    },
                    ColumnSpecification = ColumnSpecificationConverter.ToExcelColumnSpecification(alignmentParameters.ColumnSpecification),
                    RowSpecification = RowSpecificationConverter.ToExcelRowSpecification(alignmentParameters.RowSpecification),
                };
            }

            throw new ArgumentException("Invalid type. Expected AlignmentParameters.");
        }
    }
}
