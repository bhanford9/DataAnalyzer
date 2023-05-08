using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    internal abstract class StatsConfiguration<T> : IStatsConfiguration
        where T : AppDataConfig.IDataConfiguration
    {
        public void Initialize(IStatAccessorCollection parameters, AppDataConfig.IDataConfiguration applicationConfiguration) =>
            InternalInit(parameters, (T)applicationConfiguration);

        protected abstract void InternalInit(IStatAccessorCollection parameters, T configuration);
    }
}
