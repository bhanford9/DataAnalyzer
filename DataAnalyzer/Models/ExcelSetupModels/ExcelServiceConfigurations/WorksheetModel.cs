using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
  public class WorksheetModel : BasePropertyChanged
  {
    public string WorksheetName { get; set; } = string.Empty;

    public ICollection<ExcelAction> WorksheetActions { get; set; } = new List<ExcelAction>();

    public ICollection<DataClusterModel> DataClusters { get; set; } = new List<DataClusterModel>();
  }
}
