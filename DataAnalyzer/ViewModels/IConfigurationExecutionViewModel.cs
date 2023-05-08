using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
    internal interface IConfigurationExecutionViewModel : INotifyPropertyChanged
    {
        IExecutionExecutiveCommissioner ExecutiveCommissioner { get; }
        string SelectedExecutionType { get; set; }
    }
}