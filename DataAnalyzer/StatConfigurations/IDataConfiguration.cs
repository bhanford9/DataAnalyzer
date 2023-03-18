using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    /// <summary>
    /// Converts an application loaded configuration to a stat-specific configuration
    /// </summary>
    internal interface IDataConfiguration
    {
        void Initialize(IDataParameterCollection parameters, AppDataConfig.IDataConfiguration applicationConfiguration);
    }
}
