using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExecutionViewModels;

internal interface IClassSetupBoxViewModel : INotifyPropertyChanged
{
    ICommand ApplyToAll { get; }
    string ApplyToAllAccessibility { get; set; }
    string ApplyToAllType { get; set; }
    IReadOnlyCollection<string> BaseAccessibilities { get; }
    string ClassAccessibility { get; set; }
    string ClassName { get; set; }
    IReadOnlyCollection<string> PropertyAccessibilities { get; }
    IReadOnlyCollection<string> Types { get; }
    ObservableCollection<IPropertyData> Properties { get; }
}