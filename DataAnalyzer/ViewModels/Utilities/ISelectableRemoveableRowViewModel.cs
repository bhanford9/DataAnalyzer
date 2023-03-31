using System.Windows.Input;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface ISelectableRemoveableRowViewModel : IRowViewModel
    {
        ICommand Remove { get; }
        ICommand Select { get; }
    }
}