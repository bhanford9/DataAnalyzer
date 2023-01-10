using DataAnalyzer.Common.DataParameters;

namespace DataAnalyzer.Common.DataConfigurations
{
    internal abstract class DataConfiguration<T> : IDataConfiguration
        where T : ApplicationConfigurations.DataConfigurations.IDataConfiguration
    {
        public void Initialize(
            IDataParameterCollection parameters,
            ApplicationConfigurations.DataConfigurations.IDataConfiguration applicationConfiguration) =>
            this.InternalInit(parameters, (T)applicationConfiguration);

        protected abstract void InternalInit(IDataParameterCollection parameters, T configuration);
    }
}
