using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class WorksheetActionCreationModel : ActionCreationModel, IWorksheetActionCreationModel
    {
        public WorksheetActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableWorkbookActions;
    }
}
