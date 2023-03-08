using System.ComponentModel;

namespace DataAnalyzer.Models.ImportModels
{
    internal interface IImportModel : INotifyPropertyChanged
    {
        string SelectedScraperCategory { get; set; }
    }
}