using System;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects;

internal interface IComparableList<T> : IComparable, IList<T>
    where T : IComparable
{
}