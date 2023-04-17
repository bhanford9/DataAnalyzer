using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels
{
    internal class RowActionViewModel : ExcelActionViewModel, IRowActionViewModel
    {
        public RowActionViewModel(
            IRowActionCreationViewModel actionCreationViewModel,
            IRowActionApplicationViewModel actionApplicationViewModel,
            IRowActionsSummaryViewModel actionsSummaryViewModel,
            IExcelRowSpecification excelEntitySpecification)
            : base(actionCreationViewModel, actionApplicationViewModel, actionsSummaryViewModel, excelEntitySpecification)
        {
        }
    }
}
