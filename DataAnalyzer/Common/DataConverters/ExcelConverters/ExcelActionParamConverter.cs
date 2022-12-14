using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal abstract class ExcelActionParamConverter : IExcelActionParamConverter
    {
        protected ExcelActionParamConverter(ExcelService.DataActions.ActionParameters.IActionParameters excelParams)
            => Name = excelParams.Name;

        public string Name { get; }

        public abstract IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters input);

        public abstract ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters input);
    }
}
