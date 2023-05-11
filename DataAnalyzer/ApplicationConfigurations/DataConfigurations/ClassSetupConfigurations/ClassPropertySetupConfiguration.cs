using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal class ClassPropertySetupConfiguration : PropertySetupConfiguration, IClassPropertySetupConfiguration
{
    public ICollection<IPropertySetupConfiguration> Properties { get; set; }
        = new List<IPropertySetupConfiguration>();
}
