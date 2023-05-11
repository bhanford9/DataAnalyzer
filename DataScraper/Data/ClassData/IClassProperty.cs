using System.Collections.Generic;

namespace DataScraper.Data.ClassData;

public interface IClassProperty : IProperty
{
    ICollection<IProperty> Properties { get; set; }
}