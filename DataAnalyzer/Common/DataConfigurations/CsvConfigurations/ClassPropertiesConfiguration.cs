using DataAnalyzer.Common.DataParameters;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConfigurations.CsvConfigurations
{
    // This configuration is the one that is stored within the stats model
    // might want to get the namespace to suggest that so it is more intuitive
    internal class ClassPropertiesConfiguration : DataConfiguration<ApplicationConfigurations.DataConfigurations.CsvNamesDataConfiguration>
    {
        public string ClassName = string.Empty;

        public List<string> PropertyNames{ get; set; } = new();

        protected override void InternalInit(
            IDataParameterCollection parameters,
            ApplicationConfigurations.DataConfigurations.CsvNamesDataConfiguration configuration)
        {
            this.ClassName = configuration.ClassName;
            this.PropertyNames = configuration.CsvNameAndProperties
                .Where(x => x.Include)
                .Select(x => x.PropertyName)
                .ToList();
        }
    }
}
