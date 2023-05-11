using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;

internal class RowActionCreationModel : ActionCreationModel, IRowActionCreationModel
{
    public RowActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableRowActions;
}
