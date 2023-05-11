using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;

internal class WorkbookActionCreationModel : ActionCreationModel, IWorkbookActionCreationModel
{
    public WorkbookActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableWorkbookActions;
}
