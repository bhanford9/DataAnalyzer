using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
  public class ConfigurationCreationViewModel : BasePropertyChanged
  {
    private readonly ConfigurationCreationModel configurationCreationModel = BaseSingleton<ConfigurationCreationModel>.Instance;

    private bool isCreating = false;
    private string configurationDirectory = string.Empty;
    private string configurationName = string.Empty;
    private string selectedDataType = string.Empty;
    private int groupingLayersCount = 0;

    private readonly BaseCommand browseDirectory;
    private readonly BaseCommand createConfiguration;
    private readonly BaseCommand cancelChanges;
    private readonly BaseCommand saveConfiguration;

    public ConfigurationCreationViewModel()
    {
      this.browseDirectory = new BaseCommand((obj) => this.DoBrowseDirectory());
      this.createConfiguration = new BaseCommand((obj) => this.DoCreateConfiguration());
      this.cancelChanges = new BaseCommand((obj) => this.DoCancelChanges());
      this.saveConfiguration = new BaseCommand((obj) => this.DoSaveConfiguration());

      this.ConfigurationDirectory = Properties.Settings.Default.LastUsedConfigurationDirectory;
      this.ApplyConfigurationDirectory(this.ConfigurationDirectory);

      Enum.GetNames(typeof(StatType)).ToList().ForEach(x => this.DataTypes.Add(x));

      this.configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;
    }

    public ICommand BrowseDirectory => this.browseDirectory;
    public ICommand CreateConfiguration => this.createConfiguration;
    public ICommand CancelChanges => this.cancelChanges;
    public ICommand SaveConfiguration => this.saveConfiguration;

    public ObservableCollection<string> DataTypes { get; set; }
      = new ObservableCollection<string>();

    public ObservableCollection<ConfigurationGroupingViewModel> ConfigurationGroupings { get; set; }
      = new ObservableCollection<ConfigurationGroupingViewModel>();

    public ObservableCollection<LoadableRemovableRowViewModel> Configurations { get; set; }
      = new ObservableCollection<LoadableRemovableRowViewModel>();

    public bool IsCreating
    {
      get => this.isCreating;
      set => this.NotifyPropertyChanged(nameof(this.IsCreating), ref this.isCreating, value);
    }

    public string ConfigurationDirectory
    {
      get => this.configurationDirectory;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationDirectory), ref this.configurationDirectory, value);
        this.configurationCreationModel.ConfigurationDirectory = value;
      }
    }

    public string ConfigurationName
    {
      get => this.configurationName;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationName), ref this.configurationName, value);
        this.configurationCreationModel.ConfigurationName = value;
      }
    }

    public string SelectedDataType
    {
      get => this.selectedDataType;
      set
      {
        this.NotifyPropertyChanged(nameof(this.SelectedDataType), ref this.selectedDataType, value);
        this.configurationCreationModel.SelectedDataType = Enum.Parse<StatType>(value);
      }
    }

    public int GroupingLayersCount
    {
      get => this.groupingLayersCount;
      set
      {
        this.NotifyPropertyChanged(nameof(this.GroupingLayersCount), ref this.groupingLayersCount, value);

        while (this.GroupingLayersCount > this.ConfigurationGroupings.Count)
        {
          this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(this.ConfigurationGroupings.Count()));
        }

        while (this.GroupingLayersCount >= 0 && this.GroupingLayersCount < this.ConfigurationGroupings.Count)
        {
          this.ConfigurationGroupings.RemoveAt(this.ConfigurationGroupings.Count - 1);
        }
      }
    }

    private void DoBrowseDirectory()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        this.ApplyConfigurationDirectory(folderBrowserDialog.SelectedPath);
      }
    }

    private void DoCreateConfiguration()
    {
      this.IsCreating = true;
      this.ClearConfigurationData();
      this.configurationCreationModel.CreateNewDataConfiguration();
    }

    private void DoCancelChanges()
    {
      this.IsCreating = false;
      this.ClearConfigurationData();
    }

    private void ClearConfigurationData()
    {
      this.ConfigurationName = string.Empty;
      this.SelectedDataType = StatType.NotApplicable.ToString();
      this.GroupingLayersCount = 0;
      this.ConfigurationGroupings.Clear();
    }

    private void DoSaveConfiguration()
    {
      if (string.IsNullOrEmpty(this.configurationName))
      {
        // TODO --> Display that there is a problem
        return;
      }

      if (string.IsNullOrEmpty(this.selectedDataType))
      {
        // TODO --> Display that there is a problem
        return;
      }

      this.configurationCreationModel.ClearGroupingConfigurations();

      int level = 0;
      this.ConfigurationGroupings.ToList().ForEach(configGroupingViewModel =>
      {
        this.configurationCreationModel.AddGroupingConfiguration(new GroupingConfiguration()
        {
          GroupLevel = level++,
          GroupName = configGroupingViewModel.Name,
          SelectedParameter = configGroupingViewModel.SelectedParameter
        });
      });

      this.configurationCreationModel.SaveConfiguration();
    }

    private void ApplyConfigurationDirectory(string file)
    {
      if (Directory.Exists(file))
      {
        this.ConfigurationDirectory = file;
        List<string> configFiles = Directory.GetFiles(file).ToList();
        this.Configurations.Clear();

        configFiles.ForEach(configFilePath =>
        {
          string configFile = Path.GetFileName(configFilePath);
          string displayText = configFile;
          while (displayText.Contains("."))
          {
            displayText = Path.GetFileNameWithoutExtension(displayText);
          }

          this.Configurations.Add(new ConfigurationFileListItemViewModel() { Value = displayText, ToolTipText = configFile });
        });
      }
    }

    private void LoadViewModelFromConfiguration()
    {
      this.ConfigurationName = this.configurationCreationModel.DataConfiguration.Name;
      this.GroupingLayersCount = this.configurationCreationModel.DataConfiguration.GroupingConfiguration.Count;
      this.ConfigurationGroupings.Clear();

      int level = 0;
      foreach (GroupingConfiguration groupingConfig in this.configurationCreationModel.DataConfiguration.GroupingConfiguration)
      {
        this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(level++)
        {
          Name = groupingConfig.GroupName,
          SelectedParameter = groupingConfig.SelectedParameter,
        });
      }

      // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
      this.SelectedDataType = this.configurationCreationModel.DataConfiguration.StatType.ToString();
      this.IsCreating = true;
    }

    private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationCreationModel.SelectedDataType):
          this.SelectedDataType = Enum.GetName(typeof(StatType), this.configurationCreationModel.SelectedDataType);
          break;
        case nameof(this.configurationCreationModel.DataConfiguration):
          this.LoadViewModelFromConfiguration();
          break;
        case nameof(this.configurationCreationModel.RemoveLevel):
          this.ConfigurationGroupings.RemoveAt(this.configurationCreationModel.RemoveLevel);

          this.groupingLayersCount--;
          this.NotifyPropertyChanged(nameof(this.GroupingLayersCount));
          break;
        default:
          break;
      }
    }
  }
}
