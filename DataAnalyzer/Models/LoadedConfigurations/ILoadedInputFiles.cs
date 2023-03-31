using System.ComponentModel;

namespace DataAnalyzer.Models.LoadedConfigurations
{
    internal interface ILoadedInputFiles : INotifyPropertyChanged
    {
        string DataType { get; set; }
        string DataTypeKey { get; }
        string DataTypeKeyValue { get; }
        string DirectoryPath { get; set; }
        string DirectoryPathKey { get; }
        string DirectoryPathKeyValue { get; }
        string Name { get; }
    }
}