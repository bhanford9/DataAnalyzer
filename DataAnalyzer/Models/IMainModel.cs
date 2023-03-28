using DataAnalyzer.Models.LoadedConfigurations;
using System.ComponentModel;

namespace DataAnalyzer.Models
{
    internal interface IMainModel : INotifyPropertyChanged
    {
        LoadedDataContent LoadedDataContent { get; set; }
        LoadedDataStructure LoadedDataStructure { get; set; }
        LoadedInputFiles LoadedInputFiles { get; set; }

        bool ApplyInputExportTypes();
        void NotifyScraperTypeChange();
    }
}