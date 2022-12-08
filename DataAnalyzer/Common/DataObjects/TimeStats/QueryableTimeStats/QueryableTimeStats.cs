using DataAnalyzer.Services;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats
{
    internal class QueryableTimeStats : TimeStats
    {
        private readonly List<string> parameterNames = new List<string>();

        public QueryableTimeStats()
        {
            this.parameterNames.Add(nameof(this.CategoryType));
            this.parameterNames.Add(nameof(this.ContainerType));
            this.parameterNames.Add(nameof(this.TriggerType));
            this.parameterNames.Add(nameof(this.MethodName));
        }

        public CategoryType CategoryType { get; set; } = CategoryType.Other;

        public ContainerType ContainerType { get; set; } = ContainerType.Vector;

        public TriggerType TriggerType { get; set; } = TriggerType.NotApplicable;

        public string MethodName { get; set; } = string.Empty;

        protected override ICollection<string> InternalParameterNames => this.parameterNames;

        public override T GetEnumeratedParameters<T>()
        {
            return (T)(object)StatType.Queryable;
        }
    }
}
