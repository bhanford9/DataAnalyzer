using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels
{
  public class ActionSummaryTreeViewItem : BasePropertyChanged
  {
    private bool isLeaf = true;
    private string name = string.Empty;
    private string description = string.Empty;

    public ActionSummaryTreeViewItem()
    {
    }

    public ObservableCollection<ActionSummaryTreeViewItem> Children { get; }
      = new ObservableCollection<ActionSummaryTreeViewItem>();

    public bool IsLeaf
    {
      get => this.isLeaf;
      set => this.NotifyPropertyChanged(nameof(this.IsLeaf), ref this.isLeaf, value);
    }

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }

    public string Description
    {
      get => this.description;
      set => this.NotifyPropertyChanged(nameof(this.Description), ref this.description, value);
    }
  }
}
