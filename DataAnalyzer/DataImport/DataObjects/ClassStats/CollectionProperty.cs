using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataObjects.ClassStats;

internal class CollectionProperty : Property, ICollectionProperty
{
    public ICollection<IProperty> Properties { get; set; } = new List<IProperty>();

    public override int CompareTo(object obj)
    {
        if (obj is ClassProperty classProperty)
        {
            int nameComparison = this.Name.CompareTo(classProperty.Name);

            if (nameComparison == 0)
            {
                return this.Properties.FirstOrDefault(
                    x => classProperty.Properties.All(y => y.CompareTo(x) != 0)) == default
                    ? 0 : 1;
            }

            return nameComparison;
        }

        return -1;
    }
}
