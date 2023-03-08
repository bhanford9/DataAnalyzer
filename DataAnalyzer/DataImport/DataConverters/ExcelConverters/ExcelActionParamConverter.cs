using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using Service = ExcelService.DataActions.ActionParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal abstract class ExcelActionParamConverter : IExcelActionParamConverter
    {
        protected ExcelActionParamConverter(Service.IActionParameters excelParams)
            => Name = excelParams.Name;

        public string Name { get; }

        public abstract IActionParameters FromExcel(Service.IActionParameters input);

        public abstract Service.IActionParameters ToExcel(IActionParameters input);
    }
}
