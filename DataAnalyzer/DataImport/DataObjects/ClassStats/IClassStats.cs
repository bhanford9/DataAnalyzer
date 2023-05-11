namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal interface IClassStats : IStats
{
    string Name { get; set; }
    IComparableList<IProperty> Properties { get; set; }
}