namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations
{
    internal class GroupingConfiguration : DataConfiguration
    {
        public string GroupName { get; set; } = string.Empty;

        public int GroupLevel { get; set; }

        public string SelectedParameter { get; set; } = string.Empty;
    }
}
