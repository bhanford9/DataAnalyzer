using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    internal class NotSupportedDataConfiguration : DataConfiguration<AppDataConfig.NotSupportedDataConfiguration>
    {
        protected override void InternalInit(
            IDataParameterCollection parameters,
            AppDataConfig.NotSupportedDataConfiguration applicationConfiguration)
        {
        }
    }
}
