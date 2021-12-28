using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
  public abstract class ActionApplicationModel : ExcelActionModel, IActionApplicationModel
  {
    public void LoadWhereToApply(CheckableTreeViewItem baseItem)
    {
      this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);
    }

    protected abstract void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats);
  }
}