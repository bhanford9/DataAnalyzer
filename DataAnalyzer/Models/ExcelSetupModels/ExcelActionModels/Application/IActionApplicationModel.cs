using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
  public interface IActionApplicationModel : IExcelActionModel
  {
    void LoadWhereToApply(CheckableTreeViewItem baseItem);
  }
}
