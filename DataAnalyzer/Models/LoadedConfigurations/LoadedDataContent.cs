using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.LoadedConfigurations;

internal class LoadedDataContent : BasePropertyChanged, ILoadedDataContent
{
    public string Name => "Data Content";
}
