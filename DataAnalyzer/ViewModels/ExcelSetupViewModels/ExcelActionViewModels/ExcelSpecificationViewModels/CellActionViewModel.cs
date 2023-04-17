using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels
{
    internal class CellActionViewModel : ExcelActionViewModel, ICellActionViewModel
    {
        public CellActionViewModel(
            ICellActionCreationViewModel actionCreationViewModel,
            ICellActionApplicationViewModel actionApplicationViewModel,
            ICellActionsSummaryViewModel actionsSummaryViewModel,
            IExcelCellSpecification excelEntitySpecification)
            : base(actionCreationViewModel, actionApplicationViewModel, actionsSummaryViewModel, excelEntitySpecification)
        {
        }
    }
}
