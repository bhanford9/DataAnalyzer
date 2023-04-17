using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal interface IEditActionLibrary
    {
        IEditActionViewModel GetEditAction(IActionParameters actionParameters, IExcelEntitySpecification excelEntityType);
    }
}