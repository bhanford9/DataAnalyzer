using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataParameters.TimeStatParameters
{
    class QueryableParameters : TimeParameters, IQueryableParameters
    {
        public override StatType StatType => StatType.Queryable;

        protected override void InternalInitializeParameters()
        {
            this.parameters.Add(new DataParameter(stats => (stats as QueryableTimeStats).CategoryType, stats => stats is QueryableTimeStats) { Name = nameof(QueryableTimeStats.CategoryType) });
            this.parameters.Add(new DataParameter(stats => (stats as QueryableTimeStats).ContainerType, stats => stats is QueryableTimeStats) { Name = nameof(QueryableTimeStats.ContainerType) });
            this.parameters.Add(new DataParameter(stats => (stats as QueryableTimeStats).TriggerType, stats => stats is QueryableTimeStats) { Name = nameof(QueryableTimeStats.TriggerType) });
            this.parameters.Add(new DataParameter(stats => (stats as QueryableTimeStats).MethodName, stats => stats is QueryableTimeStats) { Name = nameof(QueryableTimeStats.MethodName) });
        }
    }
}
