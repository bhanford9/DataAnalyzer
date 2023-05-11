using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

internal class WorkbookActionsSummaryViewModel : ActionsSummaryViewModel, IWorkbookActionsSummaryViewModel
{
    public WorkbookActionsSummaryViewModel(
        IStatsModel statsModel,
        IStructureExecutiveCommissioner structureExecutiveCommissioner,
        IWorkbookActionsSummaryModel actionsSummaryModel,
        IExcelWorkbookSpecification excelEntityType)
        : base(statsModel, structureExecutiveCommissioner, actionsSummaryModel, excelEntityType)
    {
    }
}
