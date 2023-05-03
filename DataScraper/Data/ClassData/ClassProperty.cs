using System.Collections.Generic;

namespace DataScraper.Data.ClassData
{
    internal class ClassProperty : Property, IClassProperty
    {
        public ICollection<IProperty> Properties { get; set; } = new List<IProperty>();
    }
}
