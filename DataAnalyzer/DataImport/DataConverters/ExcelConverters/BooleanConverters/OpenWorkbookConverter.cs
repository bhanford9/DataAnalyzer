using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.DataActions.ActionParameters.WorkbookParameters;
using System;
using ExcelParms = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.BooleanConverters
{
    internal sealed class OpenWorkbookConverter : ExcelActionParamConverter, IOpenWorkbookConverter
    {
        public OpenWorkbookConverter() : base(new DisplayWorkbookParameters()) { }

        public override IActionParameters FromExcel(ExcelParms.IActionParameters input)
        {
            if (input is DisplayWorkbookParameters displayParameters)
            {
                return new BooleanOperationParameters
                {
                    DoPerform = displayParameters.DisplayAfter,
                    Name = displayParameters.Name,
                };
            }

            throw new ArgumentException("Invalid type. Excpected DisplayWorkbookParameters.");
        }

        public override ExcelParms.IActionParameters ToExcel(IActionParameters input)
        {
            if (input is BooleanOperationParameters booleanParameters)
            {
                return new DisplayWorkbookParameters
                {
                    DisplayAfter = booleanParameters.DoPerform,
                };
            }

            throw new ArgumentException("Invalid type. Excpected BooleanOperationParameters.");
        }
    }
}
