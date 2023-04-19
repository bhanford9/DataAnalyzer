using Autofac;
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
            // StatConfigurations.CsvConfigurations
            builder.RegisterTypeAncestors<IDataConfiguration, IClassPropertiesConfiguration, ClassPropertiesConfiguration>();

            // StatConfigurations.ExcelConfigurations
            builder.RegisterTypeAncestors<IDataConfiguration, IExcelConfiguration, ExcelConfiguration>();
           
            // StatConfigurations.FilteringConfigurations
            
            // StatConfigurations.GroupingConfigurations
            builder.RegisterType<IGroupingConfiguration, GroupingConfiguration>();
            builder.RegisterTypeAncestors<IGroupingConfiguration, ILinkedGroupingConfiguration, LinkedGroupingConfiguration>();
            //builder.RegisterTypeAncestors<IDataConfiguration, IGroupingDataConfiguration, GroupingDataConfiguration<AppDataConfig.IDataConfiguration>>();

            // StatConfigurations.SortingConfigurations

            // StatConfigurations
            builder.RegisterTypeAncestors<IDataConfiguration, INotSupportedDataConfiguration, NotSupportedDataConfiguration>();
        }
    }
}
