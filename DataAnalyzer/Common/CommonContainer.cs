using Autofac;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.DataParameters.CsvParameters;
using DataAnalyzer.Common.DataParameters.TimeStatParameters;

namespace DataAnalyzer.Common
{
    internal class CommonContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // Common.DataOrganizers
            builder.RegisterType<ICsvDataOrganizer, CsvDataOrganizer>();
            builder.RegisterType<IExcelDataOrganizer, ExcelDataOrganizer>();
            // TODO --> may need to register each type of available IDataConfiguration
            builder.RegisterType<IGroupingDataOrganizer, GroupingDataOrganizer<IDataConfiguration>>();
            builder.RegisterType<INotSupportedDataOrganizer, NotSupportedDataOrganizer>();

            // Common.DataParameters.CsvParameters
            builder.RegisterType<ICsvClassParameters, CsvClassParameters>();

            // Common.DataParameters.TimeStatParameters
            builder.RegisterType<IQueryableParameters, QueryableParameters>();

            // Common.DataParameters
            builder.RegisterType<IDataParameter, DataParameter>();
            builder.RegisterType<IDataParameterLibrary, DataParameterLibrary>();
        }
    }
}
