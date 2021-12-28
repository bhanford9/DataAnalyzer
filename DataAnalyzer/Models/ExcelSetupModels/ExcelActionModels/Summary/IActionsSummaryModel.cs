using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
  public interface IActionsSummaryModel
  {
    void LoadHeirarchicalSummaries(ActionSummaryTreeViewItem baseItem);
  }
}