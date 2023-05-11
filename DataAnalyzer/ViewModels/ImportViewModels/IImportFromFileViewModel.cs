using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ImportViewModels;

internal interface IImportFromFileViewModel : IImportViewModel
{
    string ActiveDirectory { get; set; }
    ICommand BrowseDirectory { get; }
    ObservableCollection<ICheckableTreeViewItem> Files { get; }
    ICommand ImportData { get; }
}