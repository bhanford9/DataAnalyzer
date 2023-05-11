﻿using System.Collections.Generic;

namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations;

internal class GroupingDataConfiguration : DataConfiguration, IGroupingDataConfiguration
{
    public GroupingDataConfiguration() { }

    public ICollection<IGroupingConfiguration> GroupingConfiguration { get; set; } = new List<IGroupingConfiguration>();
}
