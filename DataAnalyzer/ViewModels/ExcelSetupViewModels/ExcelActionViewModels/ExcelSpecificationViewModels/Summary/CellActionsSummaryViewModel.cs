using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
{
    internal class CellActionsSummaryViewModel : ActionsSummaryViewModel, ICellActionsSummaryViewModel
    {
        public CellActionsSummaryViewModel(
            IStatsModel statsModel,
            IStructureExecutiveCommissioner structureExecutiveCommissioner,
            ICellActionsSummaryModel actionsSummaryModel,
            IExcelCellSpecification excelEntityType)
            : base(statsModel, structureExecutiveCommissioner, actionsSummaryModel, excelEntityType)
        {
        }
    }
}
