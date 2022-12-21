using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal interface IActionsSummaryModel : INotifyPropertyChanged
    {
        void LoadHierarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem);
        void LoadHierarchicalSummariesFromStats(ActionSummaryTreeViewItem baseItem);
        void SaveConfiguration(string configName);
    }
}