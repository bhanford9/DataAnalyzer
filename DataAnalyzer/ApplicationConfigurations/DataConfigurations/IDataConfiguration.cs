using DataAnalyzer.Services;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    /// <summary>
    /// Configuration of data for the Setup layer that is used as an intermediate state
    /// of the data after the Import layer and before the Execution layer
    /// </summary>
    internal interface IDataConfiguration : IVersionedConfiguration
    {
        string Name { get; set; }
        
        string SavedDataFilePath { get; set; }

        IImportExecutionKey ImportExecutionKey { get; set; }
    }
}