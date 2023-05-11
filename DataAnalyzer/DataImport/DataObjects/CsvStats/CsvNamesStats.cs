using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats;

internal class CsvNamesStats : Stats, ICsvNamesStats
{
    public CsvNamesStats()
    {
        ParameterNames = new List<string>() { "CSV Headers" };
    }

    public override IReadOnlyCollection<string> ParameterNames { get; }

    public IComparableList<string> CsvNames { get; set; } = new ComparableList<string>();

    //public override T GetEnumeratedParameters<T>() => (T)(object)StatType.CsvNames;
}
