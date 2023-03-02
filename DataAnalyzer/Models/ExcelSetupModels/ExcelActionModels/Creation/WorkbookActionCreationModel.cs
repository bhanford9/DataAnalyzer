using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class WorkbookActionCreationModel : ActionCreationModel
    {
        protected override ObservableCollection<ExcelAction> GetActionCollection() => this.excelSetupModel.AvailableWorkbookActions;
    }
}
