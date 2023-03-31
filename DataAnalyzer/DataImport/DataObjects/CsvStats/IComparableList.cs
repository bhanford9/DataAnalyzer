using System;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats
{
    internal interface IComparableList : IComparable, IList<string>
    {
    }
}