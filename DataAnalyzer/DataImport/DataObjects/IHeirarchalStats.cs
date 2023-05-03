using System;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects
{
    internal interface IHeirarchalStats : IStats
    {
        ICollection<IHeirarchalStats> Children { get; set; }
        IComparable Key { get; set; }
        ICollection<IStats> Values { get; set; }
    }
}