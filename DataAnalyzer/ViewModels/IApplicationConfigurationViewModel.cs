using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
    internal interface IApplicationConfigurationViewModel : INotifyPropertyChanged
    {
        ICommand Apply { get; }
        string ConfigName { get; set; }
        ICommand SelectDirectory { get; }
        string SelectedDirectory { get; set; }
    }
}