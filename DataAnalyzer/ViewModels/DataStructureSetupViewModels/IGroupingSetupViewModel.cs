using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels;

internal interface IGroupingSetupViewModel : IDataStructureSetupViewModel
{
    ObservableCollection<IConfigurationGroupingViewModel> ConfigurationGroupings { get; }

    int GroupingLayersCount { get; set; }

    void RemoveGroupingConfiguration(int level);
}