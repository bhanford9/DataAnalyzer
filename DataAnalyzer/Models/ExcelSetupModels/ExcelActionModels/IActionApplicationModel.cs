using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public interface IActionApplicationModel : IExcelActionModel
  {
    void LoadWhereToApply(CheckableTreeViewItem baseItem);
  }
}
