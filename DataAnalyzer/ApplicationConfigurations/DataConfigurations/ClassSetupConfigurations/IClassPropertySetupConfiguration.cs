using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal interface IClassPropertySetupConfiguration : IPropertySetupConfiguration
{
    ICollection<IPropertySetupConfiguration> Properties { get; set; }
}