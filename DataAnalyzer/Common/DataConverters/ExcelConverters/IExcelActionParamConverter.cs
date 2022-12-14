namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal interface IExcelActionParamConverter
    {
        string Name { get; }

        Models.ExcelSetupModels.ExcelActionParameters.IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input);
        ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(Models.ExcelSetupModels.ExcelActionParameters.IActionParameters input);
    }
}