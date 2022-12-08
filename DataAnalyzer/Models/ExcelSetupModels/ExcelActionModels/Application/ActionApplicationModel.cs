using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
    internal abstract class ActionApplicationModel : ExcelActionModel, IActionApplicationModel
    {
        public void LoadWhereToApply(CheckableTreeViewItem baseItem)
        {
            this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);
        }

        public void ApplyAction(CheckableTreeViewItem item, IEditActionViewModel action)
        {
            this.InternalApplyAction(item, action);
        }

        protected abstract void InternalApplyAction(CheckableTreeViewItem item, IEditActionViewModel action);

        protected abstract void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats);
    }
}