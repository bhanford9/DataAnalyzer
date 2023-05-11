using Autofac;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DependencyInjectionUtilities;

namespace DataAnalyzer.ApplicationConfigurations;

internal class ApplicationConfigurationContainer
{
    public static void Register(ContainerBuilder builder)
    {
        // ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, IClassCollectionSetupConfiguration, ClassCollectionSetupConfiguration>();
        builder.RegisterType<IClassSetupConfiguration, ClassSetupConfiguration>();
        builder.RegisterTypeAncestors<IPropertySetupConfiguration, IClassPropertySetupConfiguration, ClassPropertySetupConfiguration>();
        builder.RegisterTypeAncestors<IPropertySetupConfiguration, IPropertyCollectionSetupConfiguration, PropertyCollectionSetupConfiguration>();
        builder.RegisterTypeAncestors<IPropertySetupConfiguration, ISimplePropertySetupConfiguration, SimplePropertySetupConfiguration>();

        // ApplicationConfigurations.DataConfigurations
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, ICsvNamesDataConfiguration, CsvNamesDataConfiguration>();
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, DataConfiguration>();
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, IGroupingConfiguration, GroupingConfiguration>();
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, IGroupingDataConfiguration, GroupingDataConfiguration>();
        builder.RegisterTypeAncestors<IVersionedConfiguration, IDataConfiguration, INotSupportedDataConfiguration, NotSupportedDataConfiguration>();

        // ApplicationConfigurations
        builder.RegisterTypeAncestors<IVersionedConfiguration, IApplicationConfiguration, ApplicationConfiguration>();
        builder.RegisterType<IVersionedConfiguration, VersionedConfiguration>();
    }
}
