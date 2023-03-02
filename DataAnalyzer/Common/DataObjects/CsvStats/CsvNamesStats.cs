using DataAnalyzer.Services.Enums;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects.CsvStats
{
    internal class CsvNamesStats : Stats
    {
        public CsvNamesStats()
        {
            this.ParameterNames = new List<string>() { "CSV Headers" };
        }

        public override IReadOnlyCollection<string> ParameterNames { get; }

        public ComparableList CsvNames { get; set; } = new ComparableList();

        public override T GetEnumeratedParameters<T>() => (T)(object)StatType.CsvNames;
    }
}
