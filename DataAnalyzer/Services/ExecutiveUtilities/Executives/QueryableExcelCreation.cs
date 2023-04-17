using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations.ExcelConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class QueryableExcelCreation : AggregateExecutives, IQueryableExcelCreation
    {
        // circular constructor dependencies is not supported
        // need to figure out how to get the IGroupingSetupViewModel out of this constructor
        // ... this was always an ugly dependency anyway
        // ... find the couple of things needed from the view models and expose those as actions instead
        public QueryableExcelCreation()
            : base(
                  Resolver.Resolve<IExcelConfiguration>(),
                  Resolver.Resolve<IExcelDataOrganizer>())
        {
        }

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayExcelCreation);
    }
}
