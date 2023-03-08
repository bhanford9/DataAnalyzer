using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.AlignmentConverters
{
    internal sealed class NthRowAlignmentStyleConverter : AlignmentStyleConverter
    {
        public NthRowAlignmentStyleConverter() : base(new NthRowAlignmentStyleParameters()) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is NthRowAlignmentStyleParameters nthAlignmentParams)
            {
                AlignmentParameters alignmentParameters = base.FromExcel(input) as AlignmentParameters;
                alignmentParameters.RowSpecification = new() { AllRows = false, UseNthRow = true, NthRow = nthAlignmentParams.NthRow };
                return alignmentParameters;
            }

            throw new ArgumentException("Invalid type. Excpected NthRowAlignmentStyleParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is AlignmentParameters alignmentParameters)
            {
                AlignmentStyleParameters alignmentStyle = base.ToExcel(alignmentParameters) as AlignmentStyleParameters;
                return new NthRowAlignmentStyleParameters
                {
                    Alignments = alignmentStyle.Alignments,
                    NthRow = alignmentParameters.RowSpecification.NthRow
                };
            }

            throw new ArgumentException("Invalid type. Excpected AlignmentParameters.");
        }
    }
}
