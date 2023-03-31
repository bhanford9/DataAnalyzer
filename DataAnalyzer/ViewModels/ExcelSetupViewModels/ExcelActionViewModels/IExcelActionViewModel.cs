using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal interface IExcelActionViewModel : INotifyPropertyChanged
    {
        IActionApplicationViewModel ActionApplicationViewModel { get; set; }
        IActionCreationViewModel ActionCreationViewModel { get; set; }
        IActionsSummaryViewModel ActionsSummaryViewModel { get; set; }
    }
}