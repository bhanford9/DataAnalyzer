using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

namespace DataAnalyzer.StatConfigurations.ClassCreationConfigurations
{
    internal interface IClassCreationConfiguration : IDataConfiguration
    {
        IClassSetupConfiguration ClassSetupConfiguration { get; set; }
    }
}