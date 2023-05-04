using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IClassCreationSetupViewModel : IDataStructureSetupViewModel
    {
        string ClassName { get; set; }
        ObservableCollection<IPropertyBoxViewModel> ClassPropertiesBoxes { get; set; }
    }
}