using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal interface IRowActionsSummaryModel : IActionsSummaryModel
    {
        ObservableCollection<IExcelAction> GetActionCollection();
    }
}