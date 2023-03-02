using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class RowActionCreationModel : ActionCreationModel
    {
        protected override ObservableCollection<ExcelAction> GetActionCollection() => this.excelSetupModel.AvailableRowActions;
    }
}
