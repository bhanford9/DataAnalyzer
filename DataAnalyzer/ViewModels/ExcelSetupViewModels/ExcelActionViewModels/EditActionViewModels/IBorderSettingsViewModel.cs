using DataAnalyzer.ViewModels.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal interface IBorderSettingsViewModel : INotifyPropertyChanged
    {
        string BorderName { get; set; }
        ObservableCollection<string> BorderStyles { get; }
        IColorsComboBoxViewModel ComboBoxColors { get; }
        string SelectedStyle { get; set; }
    }
}