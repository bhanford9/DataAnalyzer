using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations.ExcelConfigurations;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class QueryableExcelCreation : AggregateExecutives, IQueryableExcelCreation
    {
        public QueryableExcelCreation()
            : base(
                  Resolver.Resolve<IExcelConfiguration>(),
                  Resolver.Resolve<IExcelDataOrganizer>())
        {
        }

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayExcelCreation);
    }
}
