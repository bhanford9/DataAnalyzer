using DataAnalyzer.Common.DataParameters;
using System.Collections.Generic;
using System.Linq;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations.CsvConfigurations
{
    internal class ClassPropertiesConfiguration : DataConfiguration<AppDataConfig.CsvNamesDataConfiguration>
    {
        public string ClassName = string.Empty;

        public List<string> PropertyNames { get; set; } = new();

        protected override void InternalInit(IDataParameterCollection parameters, AppDataConfig.CsvNamesDataConfiguration configuration)
        {
            ClassName = configuration.ClassName;
            PropertyNames = configuration.CsvNameAndProperties
                .Where(x => x.Include)
                .Select(x => x.PropertyName)
                .ToList();
        }
    }
}
