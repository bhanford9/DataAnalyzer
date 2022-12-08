using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
    internal interface IActionApplicationModel : IExcelActionModel
    {
        void ApplyAction(CheckableTreeViewItem item, IEditActionViewModel action);
        void LoadWhereToApply(CheckableTreeViewItem baseItem);
    }
}
