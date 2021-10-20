using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models
{
  public class ConfigurationCreationModel : BasePropertyChanged
  {
    private SerializationService serializationService = new SerializationService();
    private DataParameterLibrary dataParameterLibrary = new DataParameterLibrary();

    private DataConfiguration dataConfiguration = new DataConfiguration();
    private IDataParameterCollection dataParameterCollection = null;
    private string configurationDirectory = string.Empty;
    private string configurationName = string.Empty;

    private StatType selectedStatType = StatType.NotApplicable;

    public StatType SelectedDataType
    {
      get => this.selectedStatType;
      set
      {
        this.NotifyPropertyChanged(nameof(this.SelectedDataType), ref this.selectedStatType, value);
        this.DataParameterCollection = this.dataParameterLibrary.GetParameters(value);
      }
    }

    public IDataParameterCollection DataParameterCollection
    {
      get => this.dataParameterCollection;
      set => this.NotifyPropertyChanged(nameof(this.DataParameterCollection), ref this.dataParameterCollection, value);
    }

    public string ConfigurationDirectory
    {
      get => this.configurationDirectory;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationDirectory), ref this.configurationDirectory, value);
        Properties.Settings.Default.LastUsedConfigurationDirectory = value;
        Properties.Settings.Default.Save();
      }
    }

    public string ConfigurationName
    {
      get => this.configurationName;
      set => this.NotifyPropertyChanged(nameof(this.ConfigurationName), ref this.configurationName, value);
    }

    public void CreateNewDataConfiguration()
    {
      this.dataConfiguration = new DataConfiguration();
    }

    public void AddGroupingConfiguration(GroupingConfiguration groupingConfig)
    {
      this.dataConfiguration.GroupingConfiguration.Add(groupingConfig);
    }

    public void SaveConfiguration()
    {
      // First, create new DateTime and Version Uid and assign to all members
      string fullFilePath = this.ConfigurationDirectory + "\\" + this.ConfigurationName + FileProperties.CONFIGURATION_FILE_EXTENSION;
      this.serializationService.JsonSerializeToFile<DataConfiguration>(this.dataConfiguration, fullFilePath);
    }
  }
}
