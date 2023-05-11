using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels;

internal class DataClusterActionViewModel : ExcelActionViewModel, IDataClusterActionViewModel
{
    public DataClusterActionViewModel(
        IDataClusterActionCreationViewModel actionCreationViewModel,
        IDataClusterActionApplicationViewModel actionApplicationViewModel,
        IDataClusterActionsSummaryViewModel actionsSummaryViewModel,
        IExcelDataClusterSpecification excelEntitySpecification)
        : base(actionCreationViewModel, actionApplicationViewModel, actionsSummaryViewModel, excelEntitySpecification)
    {
    }
}
