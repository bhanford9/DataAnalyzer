using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.StatConfigurations.GroupingConfigurations
{
    internal class LinkedGroupingConfiguration : GroupingConfiguration
    {
        public LinkedGroupingConfiguration(Func<IStats, IComparable> propertyGetter)
          : base(propertyGetter)
        {
        }

        public LinkedGroupingConfiguration Next { get; set; } = null;
    }
}
