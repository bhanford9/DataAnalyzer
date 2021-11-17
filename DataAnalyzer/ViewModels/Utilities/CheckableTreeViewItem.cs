using System.Collections.ObjectModel;
using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class CheckableTreeViewItem : BasePropertyChanged
  {
    private bool isChecked = true;
    private string name = string.Empty;
    private string path = string.Empty;

    public CheckableTreeViewItem()
    {
    }

    public ObservableCollection<CheckableTreeViewItem> Children { get; }
      = new ObservableCollection<CheckableTreeViewItem>();

    public bool IsChecked
    {
      get => this.isChecked;
      set
      {
        this.NotifyPropertyChanged(nameof(this.IsChecked), ref this.isChecked, value);

        for (int i = 0; i < this.Children.Count; i++)
        {
          this.Children[i].IsChecked = value;
        }
      }
    }

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }

    public string Path
    {
      get => this.path;
      set => this.NotifyPropertyChanged(nameof(this.Path), ref this.path, value);
    }
  }
}
