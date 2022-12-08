using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal interface IActionsSummaryModel : INotifyPropertyChanged
    {
        void LoadHeirarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem);
        void LoadHeirarchicalSummariesFromStats(ActionSummaryTreeViewItem baseItem);
        void SaveConfiguration(string configName);
    }
}