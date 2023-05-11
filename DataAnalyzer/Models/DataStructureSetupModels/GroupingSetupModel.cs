using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels;

internal class GroupingSetupModel : DataStructureSetupModel<GroupingDataConfiguration>, IGroupingSetupModel
{
    public GroupingSetupModel(
        ISerializationService serializationService,
        IConfigurationModel configurationModel)
        : base(serializationService, configurationModel)
    {
    }

    public int RemoveLevel { get; private set; } = -1;

    public void AddGroupingConfiguration(IGroupingConfiguration groupingConfig)
        => this.DataConfiguration.GroupingConfiguration.Add(groupingConfig);

    public void RemoveGroupingConfiguration(int level)
    {
        this.RemoveLevel = level;
        this.NotifyPropertyChanged(nameof(this.RemoveLevel));
    }

    public void ClearGroupingConfigurations() => this.DataConfiguration.GroupingConfiguration.Clear();

    protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
    {
        foreach (IGroupingConfiguration groupConfig in this.DataConfiguration.GroupingConfiguration)
        {
            groupConfig.DateTime = saveTime;
            groupConfig.VersionUid = saveUid;
        }
    }
}
