using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationGroupingViewModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;

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

            this.addParameter = new BaseCommand(obj => this.DoAddParameter());
            this.removeParameter = new BaseCommand(obj => this.DoRemoveParameter(obj.ToString()));

            this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;

            this.LoadParameters();
        }

        public ObservableCollection<ConfigurationGroupingViewModel> Children { get; } = new();

        public ConfigurationGroupingViewModel Parent { get; private set; } = null;

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

        private void DoAddParameter()
        {
            this.Children.Add(new ConfigurationGroupingViewModel(this.level) { IsSubRule = true, Parent = this });
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
                this.configurationCreationModel.RemoveGroupingConfiguration(this.level);
            }

            this.NotifyPropertyChanged(nameof(this.HasChildren));
        }

        private void RemoveChild(string uid)
        {
            this.Children.Remove(this.Children.First(x => x.Uid.Equals(uid)));
        }

        private void LoadParameters()
        {
            if (this.configurationCreationModel.DataParameterCollection != null)
            {
                this.ParameterNames = this.configurationCreationModel.DataParameterCollection.GetParameters()
                  .Where(x => x.CanGroupBy)
                  .Select(x => x.Name)
                  .ToList();
            }
        }

        private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationCreationModel.DataParameterCollection):
                    this.LoadParameters();
                    break;
                default:
                    break;
            }
        }
    }
}
