using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
  public abstract class SummaryItem : BasePropertyChanged, ISummaryItem
  {
    public int Level { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public abstract bool IsApplicable(IActionParameters actionParameters);

    public abstract void SetDescription(IActionParameters actionParameters);
  }
}
