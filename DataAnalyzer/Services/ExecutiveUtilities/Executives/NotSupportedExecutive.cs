using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives;

internal class NotSupportedExecutive : AggregateExecutives, INotSupportedExecutive
{
    public NotSupportedExecutive()
        : base(
              Resolver.Resolve<INotSupportedDataConfiguration>(),
              Resolver.Resolve<INotSupportedDataOrganizer>())
    {
    }

    public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayNotSupported);
}
