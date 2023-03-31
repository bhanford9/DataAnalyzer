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
        string ExportType { get; set; }
        string ExportTypeKey { get; }
        string ExportTypeKeyValue { get; }
        int GroupingsCount { get; set; }
        string GroupingsKey { get; }
        string GroupingsKeyValue { get; }
        string Name { get; }
        string StructureName { get; set; }
        string StructureNameKey { get; }
        string StructureNameKeyValue { get; }
    }
}