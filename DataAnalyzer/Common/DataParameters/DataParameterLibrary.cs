using DataAnalyzer.Common.DataParameters.CsvParameters;
using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DataAnalyzer.Services.Enums;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters
{
    // TODO --> this whole class needs to be nested dictionaries
    internal class DataParameterLibrary : IDataParameterLibrary
    {
        private readonly IReadOnlyDictionary<StatType, IDataParameterCollection> parameters;

        public DataParameterLibrary(IReadOnlyDictionary<StatType, IDataParameterCollection> parameters)
        {
            this.parameters = parameters;
        }

        internal static IReadOnlyDictionary<StatType, IDataParameterCollection> GetParameterMap() =>
            new Dictionary<StatType, IDataParameterCollection>()
            {
                { StatType.Queryable, Resolver.Resolve<IQueryableParameters>() },
                { StatType.CsvNames, Resolver.Resolve<ICsvClassParameters>() },
            };

        public IDataParameterCollection GetParameters(StatType statType) =>
            this.parameters.TryGetValue(statType, out IDataParameterCollection parameters) ? parameters : default;

        public IDataParameterCollection this[StatType statType] => GetParameters(statType);
    }
}
