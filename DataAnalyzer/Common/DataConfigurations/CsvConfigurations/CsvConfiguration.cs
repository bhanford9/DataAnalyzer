using DataAnalyzer.Common.DataParameters;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataConfigurations.CsvConfigurations
{
    internal class CsvConfiguration : DataConfiguration<ApplicationConfigurations.DataConfigurations.CsvNamesDataConfiguration>
    {
        public List<string> Names { get; set; } = new();

        protected override void InternalInit(
            IDataParameterCollection parameters,
            ApplicationConfigurations.DataConfigurations.CsvNamesDataConfiguration configuration)
        {
            // TODO --> init names with that within the configuration or parameters being passed in
            //   - the application configuraiton doesn't have any names
            //   - there is not currently a CsvParameterCollection object
            //
            // need to figure out which one should have them and get that implemented
        }
    }
}
