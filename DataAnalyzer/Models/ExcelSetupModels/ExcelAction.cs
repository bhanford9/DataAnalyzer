using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelAction : BasePropertyChanged
  {
    private string name = string.Empty;
    private string description = string.Empty;
    private bool isBuiltIn = true;

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

    public bool IsBuiltIn
    {
      get => this.isBuiltIn;
      set => this.NotifyPropertyChanged(nameof(this.IsBuiltIn), ref this.isBuiltIn, value);
    }
  }
}
