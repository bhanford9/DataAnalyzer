using DataAnalyzer.Services.ClassGenerationServices;
using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
{
    internal class ClassSetupConfiguration : DataConfiguration, IClassSetupConfiguration
    {
        public string ClassName { get; set; } = string.Empty;

        public string Accessibility { get; set; } = ClassCreationConstants.PUBLIC_ACCESS;

        public ICollection<IPropertySetupConfiguration> Properties { get; set; } = new List<IPropertySetupConfiguration>();
    }
}
