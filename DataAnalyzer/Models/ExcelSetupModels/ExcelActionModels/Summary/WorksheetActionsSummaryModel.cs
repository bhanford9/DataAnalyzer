using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
  public class WorksheetActionsSummaryModel : ActionsSummaryModel
  {
    private const string PATH_DELIMITER = "~~";

    public override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.WorksheetActions;
    }

    protected override void InternalLoadWhereToApply(ActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
    {
      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new ActionSummaryTreeViewItem()
        {
          IsLeaf = false,
          Name = workbookStats.Key.ToString()
        });

        foreach (HeirarchalStats worksheetStats in workbookStats.Children)
        {
          path += PATH_DELIMITER + worksheetStats.Key.ToString();

          baseItem.Children.Last().Children.Add(new ActionSummaryTreeViewItem()
          {
            IsLeaf = true,
            Name = worksheetStats.Key.ToString()
          });
        }
      }
    }
  }
}
