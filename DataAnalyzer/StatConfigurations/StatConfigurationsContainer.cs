using Autofac;
using DataAnalyzer.StatConfigurations.ClassCreationConfigurations;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.StatConfigurations.ExcelConfigurations;
using DataAnalyzer.StatConfigurations.GroupingConfigurations;
using DependencyInjectionUtilities;

namespace DataAnalyzer.StatConfigurations
{
    internal class StatConfigurationsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // StatConfigurations.ClassCreationConfigurations
            builder.RegisterTypeAncestors<IStatsConfiguration, IClassCreationConfiguration, ClassCreationConfiguration>();

            // StatConfigurations.CsvConfigurations
            builder.RegisterTypeAncestors<IStatsConfiguration, IClassPropertiesConfiguration, ClassPropertiesConfiguration>();

            // StatConfigurations.ExcelConfigurations
            builder.RegisterTypeAncestors<IStatsConfiguration, IExcelConfiguration, ExcelConfiguration>();
           
            // StatConfigurations.FilteringConfigurations
            
            // StatConfigurations.GroupingConfigurations
            builder.RegisterType<IGroupingConfiguration, GroupingConfiguration>();
            builder.RegisterTypeAncestors<IGroupingConfiguration, ILinkedGroupingConfiguration, LinkedGroupingConfiguration>();
            //builder.RegisterTypeAncestors<IDataConfiguration, IGroupingDataConfiguration, GroupingDataConfiguration<AppDataConfig.IDataConfiguration>>();

            // StatConfigurations.SortingConfigurations

            // StatConfigurations
            builder.RegisterTypeAncestors<IStatsConfiguration, INotSupportedDataConfiguration, NotSupportedDataConfiguration>();
        }
    }
}
