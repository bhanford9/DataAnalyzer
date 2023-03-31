using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface IRowViewModel : INotifyPropertyChanged
    {
        string Value { get; set; }
    }
}