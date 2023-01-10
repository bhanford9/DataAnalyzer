using DataAnalyzer.Common.DataParameters;

namespace DataAnalyzer.Common.DataConfigurations
{
    internal interface IDataConfiguration
    {
        void Initialize(IDataParameterCollection parameters, ApplicationConfigurations.DataConfigurations.IDataConfiguration applicationConfiguration);
    }
}
