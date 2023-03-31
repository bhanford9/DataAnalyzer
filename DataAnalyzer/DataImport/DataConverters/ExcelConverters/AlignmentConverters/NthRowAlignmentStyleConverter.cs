using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using System;
using ExcelParms = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.AlignmentConverters
{
    internal sealed class NthRowAlignmentStyleConverter : AlignmentStyleConverter, INthRowAlignmentStyleConverter
    {
        public NthRowAlignmentStyleConverter() : base(new NthRowAlignmentStyleParameters()) { }

        public override IActionParameters FromExcel(ExcelParms.IActionParameters input)
        {
            if (input is NthRowAlignmentStyleParameters nthAlignmentParams)
            {
                AlignmentParameters alignmentParameters = base.FromExcel(input) as AlignmentParameters;
                alignmentParameters.RowSpecification = new RowSpecificationParameters()
                {
                    AllRows = false,
                    UseNthRow = true,
                    NthRow = nthAlignmentParams.NthRow
                };
                return alignmentParameters;
            }

            throw new ArgumentException("Invalid type. Excpected NthRowAlignmentStyleParameters.");
        }

        public override ExcelParms.IActionParameters ToExcel(IActionParameters input)
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
