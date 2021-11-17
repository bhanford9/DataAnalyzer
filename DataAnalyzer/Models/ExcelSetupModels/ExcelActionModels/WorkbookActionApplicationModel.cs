using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public class WorkbookActionApplicationModel : ActionApplicationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.WorkbookActions;
    }
  }
}
