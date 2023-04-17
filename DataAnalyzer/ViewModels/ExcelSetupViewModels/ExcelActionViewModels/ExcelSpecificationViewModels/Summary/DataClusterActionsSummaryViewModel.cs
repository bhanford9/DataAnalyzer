using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
{
    internal class DataClusterActionsSummaryViewModel : ActionsSummaryViewModel, IDataClusterActionsSummaryViewModel
    {
        public DataClusterActionsSummaryViewModel(
            IStatsModel statsModel,
            IStructureExecutiveCommissioner structureExecutiveCommissioner,
            IDataClusterActionsSummaryModel actionsSummaryModel,
            IExcelDataClusterSpecification excelEntityType)
            : base(statsModel, structureExecutiveCommissioner, actionsSummaryModel, excelEntityType)
        {
        }
    }
}
