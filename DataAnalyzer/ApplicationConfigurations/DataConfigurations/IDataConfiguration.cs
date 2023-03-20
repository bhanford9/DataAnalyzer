using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal interface IDataConfiguration : IVersionedConfiguration
    {
        // TODO --> not necessary if keeping within the key
        ExportType ExportType { get; set; }

        string Name { get; set; }
        
        string SavedDataFilePath { get; set; }

        ImportExportKey ImportExportKey { get; set; }
    }
}