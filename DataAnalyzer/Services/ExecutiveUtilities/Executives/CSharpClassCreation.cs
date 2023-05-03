using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations.ClassCreationConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class CSharpClassCreation : AggregateExecutives
    {
        public CSharpClassCreation()
            : base(
                  Resolver.Resolve<IClassCreationConfiguration>(),
                  Resolver.Resolve<IClassCreationDataOrganizer>())
        {
        }

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayClassCreation);
    }
}
