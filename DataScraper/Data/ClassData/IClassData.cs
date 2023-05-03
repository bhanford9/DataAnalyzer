using System.Collections.Generic;

namespace DataScraper.Data.ClassData
{
    public interface IClassData : IData
    {
        string Name { get; set; }
        ICollection<IProperty> Properties { get; set; }
    }
}