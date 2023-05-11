using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal interface IPropertyCollectionSetupConfiguration : IPropertySetupConfiguration
{
    ICollection<IPropertySetupConfiguration> Properties { get; set; }
}