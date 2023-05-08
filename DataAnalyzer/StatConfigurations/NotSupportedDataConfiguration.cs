using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    internal class NotSupportedDataConfiguration : StatsConfiguration<AppDataConfig.NotSupportedDataConfiguration>, INotSupportedDataConfiguration
    {
        protected override void InternalInit(
            IStatAccessorCollection parameters,
            AppDataConfig.NotSupportedDataConfiguration applicationConfiguration)
        {
        }
    }
}
