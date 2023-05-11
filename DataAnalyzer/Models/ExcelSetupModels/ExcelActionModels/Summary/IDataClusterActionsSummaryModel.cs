using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;

internal interface IDataClusterActionsSummaryModel : IActionsSummaryModel
{
    ObservableCollection<IExcelAction> GetActionCollection();
}