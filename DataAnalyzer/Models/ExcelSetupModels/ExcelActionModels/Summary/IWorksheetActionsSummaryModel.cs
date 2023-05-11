using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;

internal interface IWorksheetActionsSummaryModel : IActionsSummaryModel
{
    ObservableCollection<IExcelAction> GetActionCollection();
}