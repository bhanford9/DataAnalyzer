using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class RowViewModel : BasePropertyChanged
  {
    private string value = string.Empty;

    public string Value
    {
      get => this.value;
      set => this.NotifyPropertyChanged(nameof(this.Value), ref this.value, value);
    }
  }
}
