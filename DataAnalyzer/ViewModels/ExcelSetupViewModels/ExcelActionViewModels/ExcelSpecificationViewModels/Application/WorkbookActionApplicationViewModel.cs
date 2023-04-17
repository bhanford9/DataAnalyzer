using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
{
    internal class WorkbookActionApplicationViewModel : ActionApplicationViewModel, IWorkbookActionApplicationViewModel
    {
        public WorkbookActionApplicationViewModel(
            IStatsModel statsModel,
            ICollection<IExcelAction> actions,
            IWorkbookActionApplicationModel actionApplicationModel,
            IEditActionLibrary editActionLibrary,
            IExcelWorkbookSpecification specification)
            : base(statsModel, editActionLibrary, actions, actionApplicationModel, specification)
        {
        }
    }
}
