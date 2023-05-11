using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities;

internal interface IColorsComboBoxViewModel : INotifyPropertyChanged
{
    ObservableCollection<string> Colors { get; }
    string SelectedColor { get; set; }
}