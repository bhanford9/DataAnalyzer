using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class ActionParameters : BasePropertyChanged, IActionParameters
  {
    private string name = string.Empty;

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }
  }
}
