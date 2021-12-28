using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
  public class WorkbookActionApplicationModel : ActionApplicationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.WorkbookActions;
    }

    protected override void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
    {
      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new CheckableTreeViewItem()
        {
          IsChecked = true,
          IsLeaf = true,
          Name = workbookStats.Key.ToString(),
          Path = path,
        });
      }
    }
  }
}
