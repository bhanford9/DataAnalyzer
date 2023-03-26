using DataAnalyzer.Services;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal interface IDataConfiguration : IVersionedConfiguration
    {
        string Name { get; set; }
        
        string SavedDataFilePath { get; set; }

        IImportExportKey ImportExportKey { get; set; }
    }
}