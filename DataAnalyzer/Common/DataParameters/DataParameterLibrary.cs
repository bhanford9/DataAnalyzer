using DataAnalyzer.Common.DataParameters.CsvParameters;
using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DataAnalyzer.Services.Enums;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters
{
    internal class DataParameterLibrary
    {
        private readonly IReadOnlyDictionary<StatType, IDataParameterCollection> parameters;

        public DataParameterLibrary()
        {
            parameters = new Dictionary<StatType, IDataParameterCollection>()
            {
                { StatType.Queryable, new QueryableParameters() },
                { StatType.CsvNames, new CsvClassParameters() },
            };
        }

        public IDataParameterCollection GetParameters(StatType statType) =>
            this.parameters.TryGetValue(statType, out IDataParameterCollection parameters) ? parameters : default;

        public IDataParameterCollection this[StatType statType] => GetParameters(statType);
    }
}
