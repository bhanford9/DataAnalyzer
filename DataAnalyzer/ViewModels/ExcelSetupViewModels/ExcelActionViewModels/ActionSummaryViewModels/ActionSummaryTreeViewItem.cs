using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;

internal class ActionSummaryTreeViewItem : BasePropertyChanged, IActionSummaryTreeViewItem
{
    private bool isLeaf = true;
    private string id = string.Empty;
    private string name = string.Empty;
    private string description = string.Empty;

    public ActionSummaryTreeViewItem()
    {
    }

    public ObservableCollection<IActionSummaryTreeViewItem> Children { get; } = new();

    public ObservableCollection<IActionSummaryExpandableViewModel> SummaryViewModels { get; } = new();

    public bool IsLeaf
    {
        get => this.isLeaf;
        set => this.NotifyPropertyChanged(ref this.isLeaf, value);
    }

    public string Id
    {
        get => this.id;
        set => this.NotifyPropertyChanged(ref this.id, value);
    }

    public string Name
    {
        get => this.name;
        set => this.NotifyPropertyChanged(ref this.name, value);
    }

    public string Description
    {
        get => this.description;
        set => this.NotifyPropertyChanged(ref this.description, value);
    }
}
