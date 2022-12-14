using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using System;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.MergeAndCenterConverters
{
    internal class HeaderMergeCenterFullConverter : ExcelActionParamConverter
    {
        public HeaderMergeCenterFullConverter() : base(new HeaderMergeCenterFullParameters()) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is HeaderMergeCenterFullParameters mergeAndCenterParams)
            {
                return new BooleanOperationParameters()
                {
                    Name = mergeAndCenterParams.Name,
                    DoPerform = true
                };
            }

            throw new ArgumentException("Invalid type. Excpected HeaderMergeCenterFullParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BooleanOperationParameters booleanParams)
            {
                return new HeaderMergeCenterFullParameters();
            }

            throw new ArgumentException("Invalid type. Excpected BooleanOperationParameters.");
        }
    }
}
