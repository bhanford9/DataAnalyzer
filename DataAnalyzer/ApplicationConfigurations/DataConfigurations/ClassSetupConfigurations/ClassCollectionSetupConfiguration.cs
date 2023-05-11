using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal class ClassCollectionSetupConfiguration : DataConfiguration, IClassCollectionSetupConfiguration
{
    public ICollection<IClassSetupConfiguration> ClassSetupConfigurations { get; set; }
        = new List<IClassSetupConfiguration>();
}
