using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelAction : BasePropertyChanged
  {
    private string name = string.Empty;
    private string description = string.Empty;
    private bool isBuiltIn = true;
    private IActionParameters actionParameters;
    private string actionParameterType = string.Empty;

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

    public IActionParameters ActionParameters
    {
      get => this.actionParameters;
      set => this.NotifyPropertyChanged(nameof(this.ActionParameters), ref this.actionParameters, value);
    }

    public string ActionParameterType
    {
      get => this.actionParameterType;
      set => this.NotifyPropertyChanged(nameof(this.ActionParameterType), ref this.actionParameterType, value);
    }
  }
}
