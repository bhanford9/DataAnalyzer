using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class GroupingDataConfiguration : DataConfiguration
    {
        public ICollection<GroupingConfiguration> GroupingConfiguration { get; set; } = new List<GroupingConfiguration>();
    }
}
