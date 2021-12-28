using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
  public class WorkbookActionsSummaryModel : ActionsSummaryModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.WorkbookActions;
    }

    protected override void InternalLoadWhereToApply(ActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
    {
      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new ActionSummaryTreeViewItem()
        {
          IsLeaf = true,
          Name = workbookStats.Key.ToString()
        });
      }
    }
  }
}
