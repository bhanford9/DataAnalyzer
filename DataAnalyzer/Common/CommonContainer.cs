using Autofac;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.DataParameters.CsvParameters;
using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DependencyInjectionUtilities;

namespace DataAnalyzer.Common
{
    internal class CommonContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // Common.DataOrganizers
            builder.RegisterType<IClassCreationDataOrganizer, ClassCreationDataOrganizer>();
            builder.RegisterType<ICsvDataOrganizer, CsvDataOrganizer>();
            builder.RegisterType<IExcelDataOrganizer, ExcelDataOrganizer>();
            // TODO --> may need to register each type of available IDataConfiguration
            builder.RegisterType<IGroupingDataOrganizer, GroupingDataOrganizer<IDataConfiguration>>();
            builder.RegisterType<INotSupportedDataOrganizer, NotSupportedDataOrganizer>();

            // Common.DataParameters.CsvParameters
            builder.RegisterAs<ICsvClassParameters, CsvClassParameters>(_ =>
            {
                CsvClassParameters parameters = new();
                parameters.AddStatAccessor();
                return parameters;
            });

            // Common.DataParameters.TimeStatParameters
            builder.RegisterAs<IQueryableParameters, QueryableParameters>(_ =>
            {
                QueryableParameters parameters = new();
                parameters.AddStatAccessor();
                return parameters;
            });

            // Common.DataParameters
            builder.RegisterGeneric(typeof(StatAccessor<>)).As(typeof(IStatAccessor<>));
            builder
                .RegisterAs<IStatAccessorLibrary, StatAccessorLibrary>(
                    _ => new StatAccessorLibrary(StatAccessorLibrary.GetStatAccessorMap()))
                .SingleInstance();
        }
    }
}
