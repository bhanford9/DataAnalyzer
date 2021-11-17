using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public abstract class ActionParameters : BasePropertyChanged, IActionParameters
  {
    private string name = string.Empty;

    // Hoperfully gauranteed unique
    protected string Delimiter => " |~| ";

    public abstract ActionCategory ActionCategory { get; }

    protected string Serialize(params object[] items)
    {
      return items.Select(x => x.ToString()).Aggregate((a, b) => a + this.Delimiter + b);
    }

    public string Name
    {
      get => this.name;
      set => this.NotifyPropertyChanged(nameof(this.Name), ref this.name, value);
    }

    public abstract string SerializedParameters { get; }

    public abstract void Deserialize();
  }
}
