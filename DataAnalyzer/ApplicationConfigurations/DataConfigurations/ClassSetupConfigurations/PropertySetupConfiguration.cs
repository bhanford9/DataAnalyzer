using DataAnalyzer.Services.ClassGenerationServices;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
{
    internal class PropertySetupConfiguration : IPropertySetupConfiguration
    {
        public string Name { get; set; } = string.Empty;

        public string Accessibility { get; set; } = ClassCreationConstants.PUBLIC_ACCESS;
    }
}
