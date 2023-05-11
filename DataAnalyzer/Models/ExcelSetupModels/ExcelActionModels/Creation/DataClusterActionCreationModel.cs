using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;

internal class DataClusterActionCreationModel : ActionCreationModel, IDataClusterActionCreationModel
{
    public DataClusterActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableDataClusterActions;
}
