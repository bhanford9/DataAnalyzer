using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
    internal interface IExcelDashboardViewModel : INotifyPropertyChanged
    {
        ICommand BrowseOutputDirectory { get; }
        string ConfigName { get; set; }
        ICommand ExecuteExcelExecution { get; }
        string OutputDirectory { get; set; }
        ICommand SaveConfiguration { get; }
        ObservableCollection<IWorkbookConfigListItemViewModel> SavedWorkbookConfigs { get; }
        ICommand StartNewConfiguration { get; }
    }
}