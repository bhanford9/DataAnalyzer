using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.WorkbookParameters;
using System;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.BooleanConverters
{
    internal sealed class OpenWorkbookConverter : ExcelActionParamConverter
    {
        public OpenWorkbookConverter() : base(new DisplayWorkbookParameters()) { }

        public override IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input)
        {
            if (input is DisplayWorkbookParameters displayParameters)
            {
                return new BooleanOperationParameters()
                {
                    DoPerform = displayParameters.DisplayAfter,
                    Name = displayParameters.Name,
                };
            }

            throw new ArgumentException("Invalid type. Excpected DisplayWorkbookParameters.");
        }

        public override ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BooleanOperationParameters booleanParameters)
            {
                return new DisplayWorkbookParameters()
                {
                    DisplayAfter = booleanParameters.DoPerform,
                };
            }

            throw new ArgumentException("Invalid type. Excpected BooleanOperationParameters.");
        }
    }
}
