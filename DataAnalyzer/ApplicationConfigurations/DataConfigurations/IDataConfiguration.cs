using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal interface IDataConfiguration : IVersionedConfiguration
    {
        ExportType ExportType { get; set; }
        string Name { get; set; }
        string SavedDataFilePath { get; set; }

        // TODO --> stat type is no longer a thing. Replace with import/category/flavor
        StatType StatType { get; set; }
    }
}