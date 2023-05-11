using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;

internal class CellActionApplicationViewModel : ActionApplicationViewModel, ICellActionApplicationViewModel
{
    public CellActionApplicationViewModel(
        IStatsModel statsModel,
        ICollection<IExcelAction> actions,
        ICellActionApplicationModel actionApplicationModel,
        IEditActionLibrary editActionLibrary,
        IExcelCellSpecification specification)
        : base(statsModel, editActionLibrary, actions, actionApplicationModel, specification)
    {
    }
}
