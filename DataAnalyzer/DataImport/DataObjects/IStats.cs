using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects;

internal interface IStats
{
    string Uid { get; }
    IReadOnlyCollection<string> ParameterNames { get; }

    //T GetEnumeratedParameters<T>();
}
