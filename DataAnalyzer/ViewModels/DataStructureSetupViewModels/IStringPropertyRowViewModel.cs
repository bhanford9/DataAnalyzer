using System.ComponentModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IStringPropertyRowViewModel : INotifyPropertyChanged
    {
        string CsvName { get; set; }
        bool Include { get; set; }
        string PropertyName { get; set; }
    }
}