using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IConfigurationGroupingViewModel : INotifyPropertyChanged
    {
        ICommand AddParameter { get; }
        ObservableCollection<IConfigurationGroupingViewModel> Children { get; }
        string GroupByText { get; }
        bool HasChildren { get; }
        bool IsSubRule { get; set; }
        string Name { get; set; }
        ICollection<string> ParameterNames { get; set; }
        IConfigurationGroupingViewModel Parent { get; }
        ICommand RemoveParameter { get; }
        string SelectedParameter { get; set; }
        string Uid { get; }

        void RemoveChild(string uid);
    }
}