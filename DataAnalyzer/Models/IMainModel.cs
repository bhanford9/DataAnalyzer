using DataAnalyzer.Models.LoadedConfigurations;
using System.ComponentModel;

namespace DataAnalyzer.Models;

internal interface IMainModel : INotifyPropertyChanged
{
    ILoadedDataContent LoadedDataContent { get; set; }
    ILoadedDataStructure LoadedDataStructure { get; set; }
    ILoadedInputFiles LoadedInputFiles { get; set; }

    bool ApplyInputExecutionTypes();
    void NotifyScraperTypeChange();
}