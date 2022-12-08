using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects
{
    internal interface IStats
    {
        string Uid { get; }
        ICollection<string> ParameterNames { get; }

        T GetEnumeratedParameters<T>();
    }
}
