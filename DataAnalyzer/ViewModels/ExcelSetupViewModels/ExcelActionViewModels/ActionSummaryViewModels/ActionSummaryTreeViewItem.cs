using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels
{
  public class ActionSummaryTreeViewItem : BasePropertyChanged
  {
    private bool isLeaf = true;
    private string name = string.Empty;

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

    public string Description => "DUMMY DESCRIPTION\r\nHello World!!\r\n\tBullet Point Information\r\nHelloWorld 2.0";
  }
}
