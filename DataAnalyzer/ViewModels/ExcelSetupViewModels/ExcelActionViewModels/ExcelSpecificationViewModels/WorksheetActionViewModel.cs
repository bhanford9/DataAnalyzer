using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels
{
    internal class WorksheetActionViewModel : ExcelActionViewModel, IWorksheetActionViewModel
    {
        public WorksheetActionViewModel(
            IWorksheetActionCreationViewModel actionCreationViewModel,
            IWorksheetActionApplicationViewModel actionApplicationViewModel,
            IWorksheetActionsSummaryViewModel actionsSummaryViewModel,
            IExcelWorksheetSpecification excelEntitySpecification)
            : base(actionCreationViewModel, actionApplicationViewModel, actionsSummaryViewModel, excelEntitySpecification)
        {
        }
    }
}
