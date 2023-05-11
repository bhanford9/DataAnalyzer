using System;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;

internal class CellActionCreationModel : ActionCreationModel, ICellActionCreationModel
{
    public CellActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    protected override ObservableCollection<IExcelAction> GetActionCollection() => throw new NotImplementedException();
}
