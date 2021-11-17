using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
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
        baseItem.Children.Add(new CheckableTreeViewItem()
        {
          IsChecked = true,
          Name = workbookStats.Key.ToString(),
          Path = workbookStats.Key.ToString()
        });
      }
    }
  }
}
