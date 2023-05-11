using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities;

internal interface IPropertyData : INotifyPropertyChanged
{
    IReadOnlyCollection<string> PropertyAccessibilities { get; }
    string Name { get; set; }
    string SelectedAccessibility { get; set; }
    string SelectedType { get; set; }
    IReadOnlyCollection<string> Types { get; }
    bool IsSimpleProperty { get; set; }
}