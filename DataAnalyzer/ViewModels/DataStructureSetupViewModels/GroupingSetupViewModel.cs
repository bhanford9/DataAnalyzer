﻿using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class GroupingSetupViewModel : DataStructureSetupViewModel<GroupingDataConfiguration>
    {
        private readonly GroupingSetupModel model;

        private int groupingLayersCount = 0;

        public GroupingSetupViewModel(GroupingSetupModel model) : base(model)
        {
            this.model = model;
            this.model.PropertyChanged += this.ModelPropertyChanged;
        }

        public ObservableCollection<ConfigurationGroupingViewModel> ConfigurationGroupings { get; } = new();

        public int GroupingLayersCount
        {
            get => this.groupingLayersCount;
            set
            {
                this.NotifyPropertyChanged(ref this.groupingLayersCount, value);
                this.mainModel.LoadedDataStructure.GroupingsCount = value;

                while (this.GroupingLayersCount > this.ConfigurationGroupings.Count)
                {
                    this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(this.ConfigurationGroupings.Count()));
                }

                while (this.GroupingLayersCount >= 0 && this.GroupingLayersCount < this.ConfigurationGroupings.Count)
                {
                    this.ConfigurationGroupings.RemoveAt(this.ConfigurationGroupings.Count - 1);
                }
            }
        }

        public override bool IsValidSetup(out string reason)
        {
            reason = string.Empty;

            if (!this.SelectedDataType.IsValid)
            {
                // TODO --> create better reason
                reason = "Must have selected Data Type";
                return false;
            }

            return true;
        }

        public override void ClearConfiguration()
        {
            this.SelectedDataType = ImportExportKey.Default;
            this.GroupingLayersCount = 0;
            this.ConfigurationGroupings.Clear();
        }

        public override void LoadViewModelFromConfiguration()
        {
            this.ConfigurationName = this.model.DataConfiguration.Name;
            this.GroupingLayersCount = this.model.DataConfiguration.GroupingConfiguration.Count;
            this.ConfigurationGroupings.Clear();

            int level = 0;
            foreach (GroupingConfiguration groupingConfig in this.model.DataConfiguration.GroupingConfiguration)
            {
                this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(level++)
                {
                    Name = groupingConfig.GroupName,
                    SelectedParameter = groupingConfig.SelectedParameter,
                });
            }
        }

        public override void ApplyConfiguration()
        {
            this.model.ClearGroupingConfigurations();

            this.model.DataConfiguration.Name = this.ConfigurationName;
            int level = 0;
            this.ConfigurationGroupings.ToList().ForEach(configGroupingViewModel =>
            {
                this.model.AddGroupingConfiguration(new GroupingConfiguration
                {
                    GroupLevel = level++,
                    GroupName = configGroupingViewModel.Name,
                    SelectedParameter = configGroupingViewModel.SelectedParameter
                });
            });
        }

        public override void SaveConfiguration() => this.model.SaveConfiguration();

        public void RemoveGroupingConfiguration(int level) => this.model.RemoveGroupingConfiguration(level);

        public override void Initialize() { }

        public override string GetDisplayStringName() => nameof(StructureExecutiveCommissioner.DisplayGroupingSetup);

        protected void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.model.RemoveLevel):
                    this.ConfigurationGroupings.RemoveAt(this.model.RemoveLevel);

                    this.groupingLayersCount--;
                    this.NotifyPropertyChanged(nameof(this.GroupingLayersCount));
                    break;
                default:
                    break;
            }
        }
    }
}
