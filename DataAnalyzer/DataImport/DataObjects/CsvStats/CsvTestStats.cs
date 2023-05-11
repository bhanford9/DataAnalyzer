using System;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats;

internal class CsvTestStats : Stats, ICsvTestStats
{
    public CsvTestStats()
    {
        ParameterNames = new[]
        {
            nameof(Date),
            nameof(Name),
            nameof(Age),
            nameof(Gender),
        };
    }

    public override IReadOnlyCollection<string> ParameterNames { get; }

    public DateTime Date { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Gender { get; set; } = string.Empty;

    //public override T GetEnumeratedParameters<T>() => (T)(object)StatType.Queryable;
}
