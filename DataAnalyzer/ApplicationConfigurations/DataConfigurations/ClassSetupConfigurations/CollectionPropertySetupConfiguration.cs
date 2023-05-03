using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
{
    internal class CollectionPropertySetupConfiguration : PropertySetupConfiguration, ICollectionPropertySetupConfiguration
    {
        public ICollection<IPropertySetupConfiguration> Properties { get; set; }
            = new List<IPropertySetupConfiguration>();
    }
}
