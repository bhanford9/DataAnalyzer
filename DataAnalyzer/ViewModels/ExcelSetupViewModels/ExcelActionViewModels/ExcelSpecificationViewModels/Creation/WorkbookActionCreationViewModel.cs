using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;

internal class WorkbookActionCreationViewModel : ActionCreationViewModel, IWorkbookActionCreationViewModel
{
    public WorkbookActionCreationViewModel(
        ICollection<IExcelAction> actions,
        IWorkbookActionCreationModel actionCreationModel,
        IExcelWorkbookSpecification excelEntityType,
        IEditActionLibrary editActionLibrary) 
        : base(actions, actionCreationModel, excelEntityType, editActionLibrary)
    {
    }
}
