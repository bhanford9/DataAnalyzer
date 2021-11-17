using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public class DataClusterActionCreationModel : ActionCreationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.DataClusterActions;
    }
  }
}
