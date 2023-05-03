using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
    internal class QueryableParameters : TimeParameters<IQueryableTimeStats>, IQueryableParameters
    {
        internal override void AddStatAccessor()
        {
            base.AddStatAccessor();
            this.statAccessors.Add(new StatAccessor<IQueryableTimeStats>(stats => stats.CategoryType, stats => true) { Name = nameof(QueryableTimeStats.CategoryType) });
            this.statAccessors.Add(new StatAccessor<IQueryableTimeStats>(stats => stats.ContainerType, stats => true) { Name = nameof(QueryableTimeStats.ContainerType) });
            this.statAccessors.Add(new StatAccessor<IQueryableTimeStats>(stats => stats.TriggerType, stats => true) { Name = nameof(QueryableTimeStats.TriggerType) });
            this.statAccessors.Add(new StatAccessor<IQueryableTimeStats>(stats => stats.MethodName, stats => true) { Name = nameof(QueryableTimeStats.MethodName) });
        }
    }
}
