using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class CsvCSharpClassCreation : AggregateExecutives, ICsvCSharpClassCreation
    {
        public CsvCSharpClassCreation()
            : base(
                  Resolver.Resolve<IClassPropertiesConfiguration>(),
                  Resolver.Resolve<ICsvDataOrganizer>())
        {
        }

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayClassCreation);
    }
}
