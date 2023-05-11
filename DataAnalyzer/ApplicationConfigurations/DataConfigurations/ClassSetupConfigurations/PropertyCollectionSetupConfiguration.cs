using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal class PropertyCollectionSetupConfiguration : PropertySetupConfiguration, IPropertyCollectionSetupConfiguration
{
    public ICollection<IPropertySetupConfiguration> Properties { get; set; }
        = new List<IPropertySetupConfiguration>();
}
