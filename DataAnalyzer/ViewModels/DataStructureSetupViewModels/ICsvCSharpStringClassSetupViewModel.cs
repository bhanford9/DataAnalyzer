using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface ICsvCSharpStringClassSetupViewModel : IDataStructureSetupViewModel
    {
        string ClassName { get; set; }
        ObservableCollection<IStringPropertyRowViewModel> CsvPropertyRows { get; set; }
    }
}