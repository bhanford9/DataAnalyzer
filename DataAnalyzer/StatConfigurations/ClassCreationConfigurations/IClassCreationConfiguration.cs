using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

namespace DataAnalyzer.StatConfigurations.ClassCreationConfigurations;

internal interface IClassCreationConfiguration : IStatsConfiguration
{
    IClassCollectionSetupConfiguration ClassSetupConfiguration { get; set; }
}