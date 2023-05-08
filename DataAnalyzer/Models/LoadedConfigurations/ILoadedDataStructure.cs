using System.ComponentModel;

namespace DataAnalyzer.Models.LoadedConfigurations
{
    internal interface ILoadedDataStructure : INotifyPropertyChanged
    {
        string DataType { get; set; }
        string DataTypeKey { get; }
        string DataTypeKeyValue { get; }
        string DirectoryPath { get; set; }
        string DirectoryPathKey { get; }
        string DirectoryPathKeyValue { get; }
        string ExecutionType { get; set; }
        string ExecutionTypeKey { get; }
        string ExecutionTypeKeyValue { get; }
        int GroupingsCount { get; set; }
        string GroupingsKey { get; }
        string GroupingsKeyValue { get; }
        string Name { get; }
        string StructureName { get; set; }
        string StructureNameKey { get; }
        string StructureNameKeyValue { get; }
    }
}