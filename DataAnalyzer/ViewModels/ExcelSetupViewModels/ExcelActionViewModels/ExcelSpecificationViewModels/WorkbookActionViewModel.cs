using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels;

internal class WorkbookActionViewModel : ExcelActionViewModel, IWorkbookActionViewModel
{
    public WorkbookActionViewModel(
        IWorkbookActionCreationViewModel actionCreationViewModel,
        IWorkbookActionApplicationViewModel actionApplicationViewModel,
        IWorkbookActionsSummaryViewModel actionsSummaryViewModel,
        IExcelWorkbookSpecification excelEntitySpecification)
        : base(actionCreationViewModel, actionApplicationViewModel, actionsSummaryViewModel, excelEntitySpecification)
    {
    }
}
