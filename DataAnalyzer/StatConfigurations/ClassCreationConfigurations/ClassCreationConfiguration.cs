using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.Common.DataParameters;

namespace DataAnalyzer.StatConfigurations.ClassCreationConfigurations
{
    internal class ClassCreationConfiguration : StatsConfiguration<ClassSetupConfiguration>, IClassCreationConfiguration
    {
        public IClassSetupConfiguration ClassSetupConfiguration { get; set; } = new ClassSetupConfiguration();

        protected override void InternalInit(
            IStatAccessorCollection parameters,
            ClassSetupConfiguration configuration)
        {
            this.ClassSetupConfiguration = configuration;
        }
    }
}
