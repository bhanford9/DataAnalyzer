using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
{
    internal class RowActionsSummaryViewModel : ActionsSummaryViewModel, IRowActionsSummaryViewModel
    {
        public RowActionsSummaryViewModel(
            IStatsModel statsModel,
            IStructureExecutiveCommissioner structureExecutiveCommissioner,
            IRowActionsSummaryModel actionsSummaryModel,
            IExcelRowSpecification excelEntityType)
            : base(statsModel, structureExecutiveCommissioner, actionsSummaryModel, excelEntityType)
        {
        }
    }
}
