using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal interface ICollectionProperty : IProperty
{
    ICollection<IProperty> Properties { get; set; }
}