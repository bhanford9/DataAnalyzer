using ModelParams = DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using Service = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal interface IExcelActionParamConverter
    {
        string Name { get; }

        ModelParams.IActionParameters FromExcel(Service.IActionParameters input);
        Service.IActionParameters ToExcel(ModelParams.IActionParameters input);
    }
}