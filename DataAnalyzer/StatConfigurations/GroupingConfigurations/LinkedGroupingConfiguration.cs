namespace DataAnalyzer.StatConfigurations.GroupingConfigurations
{
    internal class LinkedGroupingConfiguration : GroupingConfiguration, ILinkedGroupingConfiguration
    {
        public LinkedGroupingConfiguration() : base()
        {
        }

        public ILinkedGroupingConfiguration Next { get; set; } = null;
    }
}
