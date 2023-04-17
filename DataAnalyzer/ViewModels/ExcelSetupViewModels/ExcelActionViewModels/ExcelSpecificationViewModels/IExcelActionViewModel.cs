using DataAnalyzer.Services.ExcelUtilities;
using System.ComponentModel;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels
{
    internal interface IExcelActionViewModel : INotifyPropertyChanged
    {
        IActionApplicationViewModel ActionApplicationViewModel { get; }
        IActionCreationViewModel ActionCreationViewModel { get; }
        IActionsSummaryViewModel ActionsSummaryViewModel { get; }
        IExcelEntitySpecification Specification { get; }
    }
}