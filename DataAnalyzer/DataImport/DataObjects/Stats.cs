using System;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects;

internal abstract class Stats : IStats
{
    private readonly string uid = Guid.NewGuid().ToString();

    public string Uid => uid;

    // TODO --> this isn't something that applies to all stat types. need to remove
    public abstract IReadOnlyCollection<string> ParameterNames { get; }

    //public abstract T GetEnumeratedParameters<T>();
}
