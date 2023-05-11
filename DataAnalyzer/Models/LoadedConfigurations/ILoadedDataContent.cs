using System.ComponentModel;

namespace DataAnalyzer.Models.LoadedConfigurations;

internal interface ILoadedDataContent : INotifyPropertyChanged
{
    string Name { get; }
}