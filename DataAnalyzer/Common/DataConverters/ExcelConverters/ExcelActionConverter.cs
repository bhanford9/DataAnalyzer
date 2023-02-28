using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Services.Enums;
using ExcelService.DataActions;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class ExcelActionConverter
    {
        public static ExcelAction FromExcelActionInfo(ActionInfo actionInfo, ExcelEntityType excelEntityType) 
            => new()
            {
                Description = actionInfo.Description,
                IsBuiltIn = true,
                Name = actionInfo.Name,
                ActionParameters = ExcelActionParamConverters.FromExcel(actionInfo.DefaultParameters).WithExcelEntity(excelEntityType)
            };
    }
}
