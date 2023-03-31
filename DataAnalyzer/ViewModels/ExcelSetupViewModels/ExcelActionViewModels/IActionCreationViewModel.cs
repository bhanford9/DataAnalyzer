using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal interface IActionCreationViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ILoadableRemovableRowViewModel> Actions { get; }
        IEditActionViewModel CurrentAction { get; set; }
        ExcelEntityType ExcelEntityType { get; }
    }
}