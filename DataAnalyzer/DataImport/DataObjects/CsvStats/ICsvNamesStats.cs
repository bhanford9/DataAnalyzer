﻿namespace DataAnalyzer.DataImport.DataObjects.CsvStats
{
    internal interface ICsvNamesStats : IStats
    {
        ComparableList CsvNames { get; set; }
    }
}