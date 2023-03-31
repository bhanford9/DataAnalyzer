using DataAnalyzer.Services.Enums;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats
{
    internal class CsvNamesStats : Stats, ICsvNamesStats
    {
        public CsvNamesStats()
        {
            ParameterNames = new List<string>() { "CSV Headers" };
        }

        public override IReadOnlyCollection<string> ParameterNames { get; }

        public ComparableList CsvNames { get; set; } = new ComparableList();

        public override T GetEnumeratedParameters<T>() => (T)(object)StatType.CsvNames;
    }
}
