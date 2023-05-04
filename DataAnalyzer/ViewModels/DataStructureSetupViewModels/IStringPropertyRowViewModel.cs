using DataAnalyzer.Services.ClassGenerationServices;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IStringPropertyRowViewModel : INotifyPropertyChanged
    {
        string SerializedName { get; set; }
        bool Include { get; set; }
        string PropertyName { get; set; }
        PropertyType PropertyType { get; set; }
    }
}