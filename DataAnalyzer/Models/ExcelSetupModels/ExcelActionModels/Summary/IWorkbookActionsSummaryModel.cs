using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal interface IWorkbookActionsSummaryModel : IActionsSummaryModel
    {
        ObservableCollection<IExcelAction> GetActionCollection();
    }
}