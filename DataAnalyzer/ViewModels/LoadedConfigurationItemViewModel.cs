using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels;

internal class LoadedConfigurationItemViewModel : BasePropertyChanged, ILoadedConfigurationItemViewModel
{
    private string title = string.Empty;

    public LoadedConfigurationItemViewModel()
    {
    }

    public ObservableCollection<string> ConfigData { get; } = new();

    public string Title
    {
        get => this.title;
        set => this.NotifyPropertyChanged(ref this.title, value);
    }
}
