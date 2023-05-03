using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.ClassStats
{
    internal interface IClassProperty : IProperty
    {
        ICollection<IProperty> Properties { get; set; }
    }
}