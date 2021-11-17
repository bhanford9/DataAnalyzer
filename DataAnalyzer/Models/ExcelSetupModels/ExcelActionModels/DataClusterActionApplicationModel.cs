using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public class DataClusterActionApplicationModel : ActionApplicationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.DataClusterActions;
    }
  }
}
