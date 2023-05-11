using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System.ComponentModel;

namespace DataAnalyzer.Models.DataStructureSetupModels;

internal interface IGroupingSetupModel : INotifyPropertyChanged, IDataStructureSetupModel<GroupingDataConfiguration>
{
    int RemoveLevel { get; }

    void AddGroupingConfiguration(IGroupingConfiguration groupingConfig);
    void ClearGroupingConfigurations();
    void RemoveGroupingConfiguration(int level);
}