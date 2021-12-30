using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
  public class CellModel : BasePropertyChanged
  {
    // CELL DATA FORMAT
    // COLUMN ID ?

    public ICollection<ExcelAction> CellActions { get; set; } = new List<ExcelAction>();

    public object Value { get; set; } = new object();
  }
}
