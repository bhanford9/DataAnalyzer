using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels;

internal interface IExcelSetupViewModel : INotifyPropertyChanged
{
    ObservableCollection<IExcelAction> CellActions { get; }
    string CurrentState { get; set; }
    ObservableCollection<IExcelAction> DataClusterActions { get; }
    IExcelActionViewModel DataClusterActionViewModel { get; set; }
    ICommand LoadDataIntoStructure { get; }
    double LoadingProgress { get; set; }
    ObservableCollection<IExcelAction> RowActions { get; }
    IExcelActionViewModel RowActionViewModel { get; set; }
    ObservableCollection<IExcelAction> WorkbookActions { get; }
    IExcelActionViewModel WorkbookActionViewModel { get; set; }
    ObservableCollection<IExcelAction> WorksheetActions { get; }
    IExcelActionViewModel WorksheetActionViewModel { get; set; }
}