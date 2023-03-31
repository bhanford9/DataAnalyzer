using System.ComponentModel;

namespace DataAnalyzer.ViewModels.ImportViewModels
{
    internal interface IImportViewModel : INotifyPropertyChanged
    {
        string SelectedScraperCategory { get; }
    }
}