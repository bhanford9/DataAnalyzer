using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels;

internal interface IConfigurationCreationViewModel : INotifyPropertyChanged
{
    IDataStructureSetupViewModel ActiveViewModel { get; set; }
    ICommand ApplyWithoutSave { get; }
    ICommand CancelChanges { get; }
    ObservableCollection<ILoadableRemovableRowViewModel> Configurations { get; }
    ICommand CreateConfiguration { get; }
    IStructureExecutiveCommissioner ExecutiveCommissioner { get; }
    ObservableCollection<string> ExecutionTypes { get; }
    ICommand SaveConfiguration { get; }
}