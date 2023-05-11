using System.Collections;
using System.Collections.Generic;

namespace DataAnalyzerTest.DataProviders;

internal abstract class DataProvider : IEnumerable<object[]>
{
    public abstract IEnumerator<object[]> GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
