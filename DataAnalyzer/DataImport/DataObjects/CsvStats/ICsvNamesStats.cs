namespace DataAnalyzer.DataImport.DataObjects.CsvStats;

internal interface ICsvNamesStats : IStats
{
    IComparableList<string> CsvNames { get; set; }
}