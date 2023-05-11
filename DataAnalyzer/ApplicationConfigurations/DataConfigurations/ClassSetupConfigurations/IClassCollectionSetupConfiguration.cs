using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
{
    internal interface IClassCollectionSetupConfiguration : IDataConfiguration
    {
        ICollection<IClassSetupConfiguration> ClassSetupConfigurations { get; set; }
    }
}