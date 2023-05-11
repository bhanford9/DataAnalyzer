namespace DataAnalyzer.StatConfigurations.GroupingConfigurations;

internal interface ILinkedGroupingConfiguration : IGroupingConfiguration
{
    ILinkedGroupingConfiguration Next { get; set; }
}