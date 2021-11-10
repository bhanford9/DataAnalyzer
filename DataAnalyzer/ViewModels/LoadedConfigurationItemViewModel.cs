using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels
{
  public class LoadedConfigurationItemViewModel : BasePropertyChanged
  {
    private string title = string.Empty;

    public LoadedConfigurationItemViewModel()
    {
    }

    public ObservableCollection<string> ConfigData { get; set; }
      = new ObservableCollection<string>();

    public string Title
    {
      get => this.title;
      set => this.NotifyPropertyChanged(nameof(this.Title), ref this.title, value);
    }
  }
}
