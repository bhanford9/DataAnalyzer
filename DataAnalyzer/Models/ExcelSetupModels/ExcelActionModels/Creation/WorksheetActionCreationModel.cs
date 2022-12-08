using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class WorksheetActionCreationModel : ActionCreationModel
    {
        protected override ObservableCollection<ExcelAction> GetActionCollection()
        {
            return this.excelSetupModel.AvailableWorkbookActions;
        }
    }
}
