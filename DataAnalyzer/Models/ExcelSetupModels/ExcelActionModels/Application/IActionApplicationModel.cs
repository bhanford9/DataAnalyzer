using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;

internal interface IActionApplicationModel : IExcelActionModel
{
    void ApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action);
    void LoadWhereToApply(ICheckableTreeViewItem baseItem);
}
