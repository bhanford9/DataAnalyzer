using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExecutionViewModels;

internal interface IClassCreationSetupViewModel : INotifyPropertyChanged
{
    ICommand AutoDetectAllProperties { get; }
    string ClassPreviewText { get; set; }
    ICommand ClosePreview { get; }
    string ConfigName { get; set; }
    ICommand CopyAllText { get; }
    ICommand ExportClass { get; }
    bool IsPreviewing { get; set; }
    ICommand LoadInData { get; }
    ICommand PreviewClass { get; }
    ObservableCollection<IClassSetupBoxViewModel> ClassSetupBoxes { get; }
    ICommand SaveConfiguration { get; }
    ObservableCollection<IClassCreationConfigListItemViewModel> SavedConfigs { get; }
    ICommand SelectConfigDirectory { get; }
    string SelectedConfigDirectory { get; set; }
    ICommand SetAllPropertiesToStrings { get; }
}