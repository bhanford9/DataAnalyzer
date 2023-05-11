using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal class ClassStats : Stats, IClassStats
{
    public string Name { get; set; } = string.Empty;

    public IComparableList<IProperty> Properties { get; set; } = new ComparableList<IProperty>();

    public override IReadOnlyCollection<string> ParameterNames
        => new List<string>();

    //public override T GetEnumeratedParameters<T>() => throw new System.NotImplementedException();
}
