using System.Collections.Generic;

namespace DataScraper.Data.ClassData;

internal class CollectionProperty : Property, ICollectionProperty
{
    public ICollection<IProperty> Properties { get; set; } = new List<IProperty>();
}
