using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface IRowSpecificationViewModel : INotifyPropertyChanged
    {
        bool AllRows { get; set; }
        int NthRow { get; set; }
        bool NthRowEnabled { get; set; }
        bool UseNthRow { get; set; }
    }
}