using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    /// <summary>
    /// Converts an application loaded configuration to a stat-specific configuration
    /// </summary>
    internal abstract class DataConfiguration<T> : IDataConfiguration
        where T : AppDataConfig.IDataConfiguration
    {
        public void Initialize(IStatAccessorCollection parameters, AppDataConfig.IDataConfiguration applicationConfiguration) =>
            InternalInit(parameters, (T)applicationConfiguration);

        protected abstract void InternalInit(IStatAccessorCollection parameters, T configuration);
    }
}
