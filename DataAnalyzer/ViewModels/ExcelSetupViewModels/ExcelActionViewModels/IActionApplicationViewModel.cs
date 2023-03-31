using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal interface IActionApplicationViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ILoadableRemovableRowViewModel> Actions { get; }
        ICommand ApplyAction { get; }
        IEditActionViewModel CurrentAction { get; set; }
        ExcelEntityType ExcelEntityType { get; }
        ObservableCollection<ICheckableTreeViewItem> WhereToApply { get; }
    }
}