using System.Collections.Generic;
using DataAnalyzer.Common.DataConverters.CsvConverters;
using DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters;

namespace DataAnalyzer.Common.DataConverters
{
    internal class DataConverterLibrary
    {
        private readonly IReadOnlyDictionary<ConverterType, IDataConverter> converters;

        public DataConverterLibrary()
        {
            this.converters = new Dictionary<ConverterType, IDataConverter>
            {
                { ConverterType.Queryable, new QueryableTimeStatsConverter() },
                { ConverterType.CsvNames, new CsvToNameListConverter() },
            };
        }

        public IDataConverter GetConverter(ConverterType type)
        {
            return this.converters[type];
        }
    }
}
