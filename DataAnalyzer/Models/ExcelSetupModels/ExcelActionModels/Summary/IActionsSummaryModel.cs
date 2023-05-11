using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;

internal interface IActionsSummaryModel : INotifyPropertyChanged
{
    void LoadHierarchicalSummariesFromModel(IActionSummaryTreeViewItem baseItem);
    void LoadHierarchicalSummariesFromStats(IActionSummaryTreeViewItem baseItem);
    void SaveConfiguration(string configName);
}