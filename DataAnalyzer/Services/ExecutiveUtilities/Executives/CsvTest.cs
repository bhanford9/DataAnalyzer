using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives;

internal class CsvTest : AggregateExecutives, ICsvTest
{
    public CsvTest()
        : base(
              Resolver.Resolve<IClassPropertiesConfiguration>(),
              Resolver.Resolve<ICsvDataOrganizer>())
    {
    }

    // TODO --> I don't love having just a string here. I think I prever having the view model here, but it may be overkill
    public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayClassCreation);
}
