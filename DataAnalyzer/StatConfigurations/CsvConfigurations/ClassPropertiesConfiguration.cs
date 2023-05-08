using DataAnalyzer.Common.DataParameters;
using System.Collections.Generic;
using System.Linq;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations.CsvConfigurations
{
    internal class ClassPropertiesConfiguration : StatsConfiguration<AppDataConfig.CsvNamesDataConfiguration>, IClassPropertiesConfiguration
    {
        public string ClassName { get; set; } = string.Empty;

        public List<string> PropertyNames { get; set; } = new();

        protected override void InternalInit(
            IStatAccessorCollection parameters,
            AppDataConfig.CsvNamesDataConfiguration configuration)
        {
            ClassName = configuration.ClassName;
            PropertyNames = configuration.CsvNameAndProperties
                .Where(x => x.Include)
                .Select(x => x.PropertyName)
                .ToList();
        }
    }
}
