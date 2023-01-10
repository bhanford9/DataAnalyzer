using DataAnalyzer.Services;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects.CsvStats
{
    internal class CsvNamesStats : Stats
    {
        public override ICollection<string> ParameterNames { get; } = new List<string>();

        public override T GetEnumeratedParameters<T>()
        {
            return (T)(object)StatType.CsvNames;
        }
    }
}
