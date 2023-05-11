using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

internal class WorksheetActionsSummaryViewModel : ActionsSummaryViewModel, IWorksheetActionsSummaryViewModel
{
    public WorksheetActionsSummaryViewModel(
        IStatsModel statsModel,
        IStructureExecutiveCommissioner structureExecutiveCommissioner,
        IWorksheetActionsSummaryModel actionsSummaryModel,
        IExcelWorksheetSpecification excelEntityType)
        : base(statsModel, structureExecutiveCommissioner, actionsSummaryModel, excelEntityType)
    {
    }
}
