using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class ConfigurationGroupingViewModel : BasePropertyChanged, IConfigurationGroupingViewModel
    {
        private readonly IStatsModel statsModel;
        private readonly IConfigurationModel configurationModel;
        private readonly IGroupingSetupViewModel parentViewModel;
        //private readonly IStructureExecutiveCommissioner executiveCommissioner;

        private readonly int level = 0;
        private string name = string.Empty;
        private string selectedParameter = string.Empty;
        private bool isSubRule = false;
        private ICollection<string> parameterNames = new List<string>();

        private readonly BaseCommand addParameter;
        private readonly BaseCommand removeParameter;

        public ConfigurationGroupingViewModel(
            IStatsModel statsModel,
            IConfigurationModel configurationModel,
            IGroupingSetupViewModel parent,
            //IStructureExecutiveCommissioner executiveCommissioner,
            int level)
        {
            this.statsModel = statsModel;
            this.configurationModel = configurationModel;
            this.parentViewModel = parent;
            //this.executiveCommissioner = executiveCommissioner;
            this.level = level;

            this.addParameter = new BaseCommand(obj => this.DoAddParameter());
            this.removeParameter = new BaseCommand(obj => this.DoRemoveParameter(obj.ToString()));

            statsModel.PropertyChanged += this.StatsModelPropertyChanged;

            this.LoadParameters();
        }

        public ObservableCollection<IConfigurationGroupingViewModel> Children { get; } = new();

        public IConfigurationGroupingViewModel Parent { get; private set; } = null;

        public ICommand AddParameter => this.addParameter;
        public ICommand RemoveParameter => this.removeParameter;

        public bool HasChildren => this.Children.Count > 0;

        public string Uid { get; } = Guid.NewGuid().ToString();

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public string SelectedParameter
        {
            get => this.selectedParameter;
            set => this.NotifyPropertyChanged(ref this.selectedParameter, value);
        }

        public string GroupByText => this.IsSubRule ? "And By:" : this.level == 0 ? "Group By:" : "Then By:";

        public bool IsSubRule
        {
            get => this.isSubRule;
            set => this.NotifyPropertyChanged(ref this.isSubRule, value);
        }

        public ICollection<string> ParameterNames
        {
            get => this.parameterNames;
            set => this.NotifyPropertyChanged(ref this.parameterNames, value);
        }

        public void RemoveChild(string uid)
        {
            for (int i = 0; i < this.Children.Count; i++)
            {
                if (this.Children[i].Uid.Equals(uid))
                {
                    this.Children.RemoveAt(i);
                    break;
                }
            }
        }

        private void DoAddParameter()
        {
            this.Children.Add(new ConfigurationGroupingViewModel(
                this.statsModel,
                this.configurationModel,
                this.parentViewModel,
                this.level)
            { IsSubRule = true, Parent = this });

            this.NotifyPropertyChanged(nameof(this.HasChildren));
        }

        private void DoRemoveParameter(string uid)
        {
            if (this.isSubRule)
            {
                this.Parent.RemoveChild(uid);
            }
            else
            {
                this.parentViewModel.RemoveGroupingConfiguration(this.level);
                // TODO --> I don't think this was doing anything 
                //(this.executiveCommissioner.GetInitializedViewModel() as GroupingSetupViewModel)
                //    .RemoveGroupingConfiguration(this.level);
            }

            this.NotifyPropertyChanged(nameof(this.HasChildren));
        }

        private void LoadParameters()
        {
            if (this.statsModel.DataAccessorCollection != null)
            {
                this.ParameterNames = this.statsModel.DataAccessorCollection.GetStatAccessors()
                    .OfType<IGroupableStatAccessor<IStats>>()
                    .Where(x => x.CanGroupBy)
                    .Select(x => x.Name)
                    .ToList();
            }
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.statsModel.DataAccessorCollection):
                    this.LoadParameters();
                break;
                default:
                    break;
            }
        }
    }
}
