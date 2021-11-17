using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public abstract class ActionApplicationModel : ExcelActionModel, IActionApplicationModel
  {
    // TODO --> this is probably not the best place for this
    protected const string PATH_DELIMITER = "_";

    public void LoadWhereToApply(CheckableTreeViewItem baseItem)
    {
      this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);
    }

    protected abstract void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats);
  }
}