using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal interface IEditActionLibrary
    {
        IEditActionViewModel GetEditAction(IActionParameters actionParameters, ExcelEntityType excelEntityType);
    }
}