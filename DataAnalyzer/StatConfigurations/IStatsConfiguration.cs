using DataAnalyzer.Common.DataParameters;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations
{
    /// <summary>
    /// Converts an application loaded configuration to a stat-specific configuration so the
    /// IStats can be loaded into an organized structure in a polymorphic/OO way
    /// </summary>
    internal interface IStatsConfiguration
    {
        void Initialize(IStatAccessorCollection parameters, AppDataConfig.IDataConfiguration applicationConfiguration);
    }
}
