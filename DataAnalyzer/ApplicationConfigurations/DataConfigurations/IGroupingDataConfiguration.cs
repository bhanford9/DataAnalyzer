using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations;

internal interface IGroupingDataConfiguration : IDataConfiguration
{
    ICollection<IGroupingConfiguration> GroupingConfiguration { get; set; }
}