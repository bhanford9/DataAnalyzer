using System;

namespace DataAnalyzer.DataImport.DataObjects.ClassStats
{
    internal interface IProperty : IComparable
    {
        string Name { get; set; }
    }
}
