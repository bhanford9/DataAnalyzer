using System.Collections.Generic;

namespace DataScraper.Data.ClassData;

public class ClassData : IClassData
{
    public string Name { get; set; } = string.Empty;

    public ICollection<IProperty> Properties { get; set; } = new List<IProperty>();
}
