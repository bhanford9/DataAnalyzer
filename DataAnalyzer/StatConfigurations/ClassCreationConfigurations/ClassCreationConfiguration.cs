using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.Common.DataParameters;

namespace DataAnalyzer.StatConfigurations.ClassCreationConfigurations;

internal class ClassCreationConfiguration :
    StatsConfiguration<ClassCollectionSetupConfiguration>,
    IClassCreationConfiguration
{
    public IClassCollectionSetupConfiguration ClassSetupConfiguration { get; set; }
        = new ClassCollectionSetupConfiguration();

    protected override void InternalInit(
        IStatAccessorCollection parameters,
        ClassCollectionSetupConfiguration configuration)
    {
        this.ClassSetupConfiguration = configuration;
    }
}
