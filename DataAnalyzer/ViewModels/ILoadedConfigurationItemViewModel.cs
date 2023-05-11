using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels;

internal interface ILoadedConfigurationItemViewModel : INotifyPropertyChanged
{
    ObservableCollection<string> ConfigData { get; }
    string Title { get; set; }
}