using DataAnalyzer.Services.ClassGenerationServices;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;

internal class SimplePropertySetupConfiguration : PropertySetupConfiguration, ISimplePropertySetupConfiguration
{
    public string PropertyType { get; set; } = ClassCreationConstants.STRING_PROPERTY_TYPE;
}
