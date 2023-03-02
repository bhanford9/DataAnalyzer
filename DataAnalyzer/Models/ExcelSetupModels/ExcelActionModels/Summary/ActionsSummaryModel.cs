using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal abstract class ActionsSummaryModel : BasePropertyChanged, IActionsSummaryModel
    {
        protected readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;
        protected readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

        public void LoadHierarchicalSummariesFromStats(ActionSummaryTreeViewItem baseItem) => this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);

        public abstract void LoadHierarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem);

        public abstract ObservableCollection<ExcelAction> GetActionCollection();

        public void SaveConfiguration(string configName) => this.excelSetupModel.SaveWorkbookConfiguration(configName);

        protected abstract void InternalLoadWhereToApply(ActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> hierarchalStats);
    }
}
