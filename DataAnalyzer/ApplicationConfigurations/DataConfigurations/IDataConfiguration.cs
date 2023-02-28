using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal interface IDataConfiguration : IVersionedConfiguration
    {
        ExportType ExportType { get; set; }
        string Name { get; set; }
        string SavedDataFilePath { get; set; }
        StatType StatType { get; set; }
    }
}