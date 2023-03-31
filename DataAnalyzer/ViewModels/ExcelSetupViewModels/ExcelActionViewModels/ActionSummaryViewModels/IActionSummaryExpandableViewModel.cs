using System.ComponentModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels
{
    internal interface IActionSummaryExpandableViewModel : INotifyPropertyChanged
    {
        string ActionDescription { get; set; }
        string ActionName { get; set; }
        ICommand CancelRemove { get; }
        string DescriptionPreview { get; set; }
        string DetailedDescription { get; set; }
        string PathId { get; set; }
        ICommand PreviewRemove { get; }
        ICommand RemoveAllOccurrences { get; }
        ICommand RemoveOccurrence { get; }
        bool RemovePopupVisible { get; set; }
    }
}