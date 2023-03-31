using System.Windows.Input;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    internal interface ILoadableRemovableRowViewModel : IRowViewModel
    {
        bool IsRemovable { get; set; }
        ICommand Load { get; }
        ICommand Remove { get; }
        string ToolTipText { get; set; }
    }
}