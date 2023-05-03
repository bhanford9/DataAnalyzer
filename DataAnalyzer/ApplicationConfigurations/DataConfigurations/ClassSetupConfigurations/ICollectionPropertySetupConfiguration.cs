using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
{
    internal interface ICollectionPropertySetupConfiguration : IPropertySetupConfiguration
    {
        ICollection<IPropertySetupConfiguration> Properties { get; set; }
    }
}