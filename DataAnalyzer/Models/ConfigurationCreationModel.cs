using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models
{
  public class ConfigurationCreationModel : BasePropertyChanged
  {
    private readonly SerializationService serializationService = new SerializationService();
    private readonly DataParameterLibrary dataParameterLibrary = new DataParameterLibrary();
    private IDataParameterCollection dataParameterCollection = null;
    private string configurationDirectory = string.Empty;
    private string configurationName = string.Empty;

    private StatType selectedStatType = StatType.NotApplicable;

    public int RemoveLevel { get; private set; } = -1;
    public DataConfiguration DataConfiguration { get; private set; } = new DataConfiguration();

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
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationName), ref this.configurationName, value);
        this.DataConfiguration.Name = value;
      }
    }

    public void CreateNewDataConfiguration()
    {
      this.DataConfiguration = new DataConfiguration();
    }

    public void AddGroupingConfiguration(GroupingConfiguration groupingConfig)
    {
      this.DataConfiguration.GroupingConfiguration.Add(groupingConfig);
    }

    public void RemoveGroupingConfiguration(int level)
    {
      this.RemoveLevel = level;
      this.NotifyPropertyChanged(nameof(this.RemoveLevel));
    }

    public void ClearGroupingConfigurations()
    {
      this.DataConfiguration.GroupingConfiguration.Clear();
    }

    public void LoadConfiguration(string configName)
    {
      string filePath = this.ConfigurationDirectory + "/" + configName + FileProperties.CONFIGURATION_FILE_EXTENSION;
      this.DataConfiguration = this.serializationService.JsonDeserializeFromFile<DataConfiguration>(filePath);
      this.NotifyPropertyChanged(nameof(this.DataConfiguration));
    }

    public void SaveConfiguration()
    {
      DateTime saveTime = DateTime.Now;
      string saveUid = Guid.NewGuid().ToString();

      foreach (GroupingConfiguration groupConfig in this.DataConfiguration.GroupingConfiguration)
      {
        groupConfig.DateTime = saveTime;
        groupConfig.VersionUid = saveUid;
      }

      this.DataConfiguration.DateTime = saveTime;
      this.DataConfiguration.VersionUid = saveUid;
      this.DataConfiguration.StatType = this.selectedStatType;

      string fullFilePath = this.ConfigurationDirectory + "\\" + this.ConfigurationName + FileProperties.CONFIGURATION_FILE_EXTENSION;
      this.serializationService.JsonSerializeToFile(this.DataConfiguration, fullFilePath);
    }
  }
}
