using DataAnalyzer.Common.DataParameters;
using System.Collections.Generic;
using System.Linq;

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
            //   - IDataParameterCollection has names, but it also has grouping/sorting capabilities
            //      These should be split out into interfaces and then there should be CSV and Grouping
            //      parameter collections that inherit these

            this.Names = parameters.GetParameters().Select(x => x.Name).ToList();
        }
    }
}
