using DataAnalyzer.Services.Enums;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats
{
    internal class QueryableTimeStats : TimeStats
    {
        private readonly List<string> parameterNames = new();

        public QueryableTimeStats()
        {
            parameterNames.Add(nameof(CategoryType));
            parameterNames.Add(nameof(ContainerType));
            parameterNames.Add(nameof(TriggerType));
            parameterNames.Add(nameof(MethodName));
        }

        public CategoryType CategoryType { get; set; } = CategoryType.Other;

        public ContainerType ContainerType { get; set; } = ContainerType.Vector;

        public TriggerType TriggerType { get; set; } = TriggerType.NotApplicable;

        public string MethodName { get; set; } = string.Empty;

        protected override ICollection<string> InternalParameterNames => parameterNames;

        public override T GetEnumeratedParameters<T>() => (T)(object)StatType.Queryable;
    }
}
