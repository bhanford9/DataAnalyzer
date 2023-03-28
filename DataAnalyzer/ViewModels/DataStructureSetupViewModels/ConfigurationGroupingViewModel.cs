using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class ConfigurationGroupingViewModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly StructureExecutiveCommissioner executiveCommissioner = BaseSingleton<StructureExecutiveCommissioner>.Instance;

        private readonly int level = 0;
        private string name = string.Empty;
        private string selectedParameter = string.Empty;
        private bool isSubRule = false;
        private ICollection<string> parameterNames = new List<string>();

        private readonly BaseCommand addParameter;
        private readonly BaseCommand removeParameter;

        public ConfigurationGroupingViewModel(int level)
        {
            this.level = level;

            addParameter = new BaseCommand(obj => DoAddParameter());
            removeParameter = new BaseCommand(obj => DoRemoveParameter(obj.ToString()));

            configurationCreationModel.PropertyChanged += ConfigurationCreationModelPropertyChanged;

            LoadParameters();
        }

        public ObservableCollection<ConfigurationGroupingViewModel> Children { get; } = new();

        public ConfigurationGroupingViewModel Parent { get; private set; } = null;

        public ICommand AddParameter => addParameter;
        public ICommand RemoveParameter => removeParameter;

        public bool HasChildren => Children.Count > 0;

        public string Uid { get; } = Guid.NewGuid().ToString();

        public string Name
        {
            get => name;
            set => NotifyPropertyChanged(ref name, value);
        }

        public string SelectedParameter
        {
            get => selectedParameter;
            set => NotifyPropertyChanged(ref selectedParameter, value);
        }

        public string GroupByText => IsSubRule ? "And By:" : level == 0 ? "Group By:" : "Then By:";

        public bool IsSubRule
        {
            get => isSubRule;
            set => NotifyPropertyChanged(ref isSubRule, value);
        }

        public ICollection<string> ParameterNames
        {
            get => parameterNames;
            set => NotifyPropertyChanged(ref parameterNames, value);
        }

        private void DoAddParameter()
        {
            Children.Add(new ConfigurationGroupingViewModel(level) { IsSubRule = true, Parent = this });
            NotifyPropertyChanged(nameof(HasChildren));
        }

        private void DoRemoveParameter(string uid)
        {
            if (isSubRule)
            {
                Parent.RemoveChild(uid);
            }
            else
            {
                (executiveCommissioner.GetInitializedViewModel() as GroupingSetupViewModel).RemoveGroupingConfiguration(level);
            }

            NotifyPropertyChanged(nameof(HasChildren));
        }

        private void RemoveChild(string uid) => Children.Remove(Children.First(x => x.Uid.Equals(uid)));

        private void LoadParameters()
        {
            if (configurationCreationModel.DataParameterCollection != null)
            {
                ParameterNames = configurationCreationModel.DataParameterCollection.GetParameters()
                  .Where(x => x.CanGroupBy)
                  .Select(x => x.Name)
                  .ToList();
            }
        }

        private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(configurationCreationModel.DataParameterCollection):
                    LoadParameters();
                    break;
                default:
                    break;
            }
        }
    }
}
