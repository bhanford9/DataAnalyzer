using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;

internal interface IActionSummaryTreeViewItem : INotifyPropertyChanged
{
    ObservableCollection<IActionSummaryTreeViewItem> Children { get; }
    string Description { get; set; }
    string Id { get; set; }
    bool IsLeaf { get; set; }
    string Name { get; set; }
    ObservableCollection<IActionSummaryExpandableViewModel> SummaryViewModels { get; }
}