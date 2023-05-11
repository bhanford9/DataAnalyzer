using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;

internal class WorksheetActionApplicationViewModel : ActionApplicationViewModel, IWorksheetActionApplicationViewModel
{
    public WorksheetActionApplicationViewModel(
        IStatsModel statsModel,
        ICollection<IExcelAction> actions,
        IWorksheetActionApplicationModel actionApplicationModel,
        IEditActionLibrary editActionLibrary,
        IExcelWorksheetSpecification specification)
        : base(statsModel, editActionLibrary, actions, actionApplicationModel, specification)
    {
    }
}
