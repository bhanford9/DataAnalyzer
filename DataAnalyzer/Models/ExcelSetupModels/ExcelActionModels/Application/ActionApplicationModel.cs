using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
    internal abstract class ActionApplicationModel : ExcelActionModel, IActionApplicationModel
    {
        protected ActionApplicationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        public void LoadWhereToApply(ICheckableTreeViewItem baseItem) => this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);

        public void ApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action) => this.InternalApplyAction(item, action);

        protected abstract void InternalApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action);

        protected abstract void InternalLoadWhereToApply(ICheckableTreeViewItem baseItem, ICollection<IHeirarchalStats> heirarchalStats);
    }
}