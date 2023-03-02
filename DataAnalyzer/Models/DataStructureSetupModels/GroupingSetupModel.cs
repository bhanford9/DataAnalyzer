using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class GroupingSetupModel : DataStructureSetupModel<GroupingDataConfiguration>
    {
        public GroupingSetupModel()
        {
        }

        public int RemoveLevel { get; private set; } = -1;

        public void AddGroupingConfiguration(GroupingConfiguration groupingConfig) => this.DataConfiguration.GroupingConfiguration.Add(groupingConfig);

        public void RemoveGroupingConfiguration(int level)
        {
            this.RemoveLevel = level;
            this.NotifyPropertyChanged(nameof(this.RemoveLevel));
        }

        public void ClearGroupingConfigurations() => this.DataConfiguration.GroupingConfiguration.Clear();

        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
            foreach (GroupingConfiguration groupConfig in this.DataConfiguration.GroupingConfiguration)
            {
                groupConfig.DateTime = saveTime;
                groupConfig.VersionUid = saveUid;
            }
        }
    }
}
