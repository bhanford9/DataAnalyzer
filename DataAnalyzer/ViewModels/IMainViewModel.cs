using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels
{
    internal interface IMainViewModel
    {
        ObservableCollection<LoadedConfigurationItemViewModel> LoadedConfigs { get; }
    }
}