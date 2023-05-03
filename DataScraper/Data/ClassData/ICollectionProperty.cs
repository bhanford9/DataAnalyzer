using System.Collections.Generic;

namespace DataScraper.Data.ClassData
{
    public interface ICollectionProperty : IProperty
    {
        ICollection<IProperty> Properties { get; set; }
    }
}