namespace DataAnalyzer.ApplicationConfigurations.DataConfigurations;

internal interface IGroupingConfiguration : IDataConfiguration
{
    int GroupLevel { get; set; }
    string GroupName { get; set; }
    string SelectedParameter { get; set; }
}