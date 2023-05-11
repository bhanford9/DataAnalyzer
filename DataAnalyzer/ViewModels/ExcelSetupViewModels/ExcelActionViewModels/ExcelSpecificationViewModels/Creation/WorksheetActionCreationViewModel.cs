using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;

internal class WorksheetActionCreationViewModel : ActionCreationViewModel, IWorksheetActionCreationViewModel
{
    public WorksheetActionCreationViewModel(
        ICollection<IExcelAction> actions,
        IWorksheetActionCreationModel actionCreationModel,
        IExcelWorksheetSpecification excelEntityType,
        IEditActionLibrary editActionLibrary)
        : base(actions, actionCreationModel, excelEntityType, editActionLibrary)
    {
    }
}
