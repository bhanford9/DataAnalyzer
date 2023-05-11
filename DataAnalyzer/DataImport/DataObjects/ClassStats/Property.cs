namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal abstract class Property : IProperty
{
    public string Name { get; set; } = string.Empty;

    public abstract int CompareTo(object obj);
}
