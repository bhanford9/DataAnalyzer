using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public class WorkbookActionCreationModel : ActionCreationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.WorkbookActions;
    }
  }
}
