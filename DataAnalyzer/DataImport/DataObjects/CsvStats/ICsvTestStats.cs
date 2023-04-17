using System;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats
{
    internal interface ICsvTestStats : IStats
    {
        int Age { get; set; }
        DateTime Date { get; set; }
        string Gender { get; set; }
        string Name { get; set; }
    }
}