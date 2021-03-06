using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
  public class DataClusterModel : BasePropertyChanged
  {
    public ICollection<RowModel> Rows { get; set; } = new List<RowModel>();

    public RowModel TitleRow { get; set; } = new RowModel();

    public ICollection<ExcelAction> DataClusterActions { get; set; } = new List<ExcelAction>();

    public string Name { get; set; } = string.Empty;

    public int StartRowIndex { get; set; }

    public int StartColIndex { get; set; }

    public bool UseClusterId { get; set; }
  }
}
