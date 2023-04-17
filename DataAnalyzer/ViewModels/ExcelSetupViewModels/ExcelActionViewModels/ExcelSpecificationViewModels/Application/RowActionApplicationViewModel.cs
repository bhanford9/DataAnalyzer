using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
{
    internal class RowActionApplicationViewModel : ActionApplicationViewModel, IRowActionApplicationViewModel
    {
        public RowActionApplicationViewModel(
            IStatsModel statsModel,
            ICollection<IExcelAction> actions,
            IRowActionApplicationModel actionApplicationModel,
            IEditActionLibrary editActionLibrary,
            IExcelRowSpecification specification)
            : base(statsModel, editActionLibrary, actions, actionApplicationModel, specification)
        {
        }
    }
}
