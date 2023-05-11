using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;

internal abstract class ActionsSummaryModel : BasePropertyChanged, IActionsSummaryModel
{
    protected readonly IExcelSetupModel excelSetupModel;
    protected readonly IStatsModel statsModel;

    public ActionsSummaryModel(
        IStatsModel statsModel,
        IExcelSetupModel excelSetupModel)
    {
        this.statsModel = statsModel;
        this.excelSetupModel = excelSetupModel;
    }

    public void LoadHierarchicalSummariesFromStats(IActionSummaryTreeViewItem baseItem) => this.InternalLoadWhereToApply(baseItem, this.statsModel.HeirarchalStats.Children);

    public abstract void LoadHierarchicalSummariesFromModel(IActionSummaryTreeViewItem baseItem);

    public abstract ObservableCollection<IExcelAction> GetActionCollection();

    public void SaveConfiguration(string configName) => this.excelSetupModel.SaveWorkbookConfiguration(configName);

    protected abstract void InternalLoadWhereToApply(IActionSummaryTreeViewItem baseItem, ICollection<IHeirarchalStats> hierarchalStats);
}
