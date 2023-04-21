using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
    internal class QueryableParameters : TimeParameters<IQueryableTimeStats>, IQueryableParameters
    {
        public override StatType StatType => StatType.Queryable;

        internal override void AddParameters()
        {
            base.AddParameters();
            this.parameters.Add(new DataParameter<IQueryableTimeStats>(stats => stats.CategoryType, stats => true) { Name = nameof(QueryableTimeStats.CategoryType) });
            this.parameters.Add(new DataParameter<IQueryableTimeStats>(stats => stats.ContainerType, stats => true) { Name = nameof(QueryableTimeStats.ContainerType) });
            this.parameters.Add(new DataParameter<IQueryableTimeStats>(stats => stats.TriggerType, stats => true) { Name = nameof(QueryableTimeStats.TriggerType) });
            this.parameters.Add(new DataParameter<IQueryableTimeStats>(stats => stats.MethodName, stats => true) { Name = nameof(QueryableTimeStats.MethodName) });
        }
    }
}
