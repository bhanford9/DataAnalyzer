using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Common.DataParameters;
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

      configurationCreationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;

      this.Configurations.Add(new LoadableRemovableRowViewModel() { Value = "Hello" });
      this.Configurations.Add(new LoadableRemovableRowViewModel() { Value = "World" });
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
      this.configurationCreationModel.CreateNewDataConfiguration();
    }

    private void DoCancelChanges()
    {
      this.IsCreating = false;
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

      int level = 0;
      this.ConfigurationGroupings.ToList().ForEach(configGroupingViewModel =>
      {
        this.configurationCreationModel.AddGroupingConfiguration(new GroupingConfiguration()
        {
          GroupLevel = level++,
          GroupName = configGroupingViewModel.Name,
          Accessor = this.configurationCreationModel.DataParameterCollection.GetStatAccessor(configGroupingViewModel.SelectedParameter)
        });
      });

      this.configurationCreationModel.SaveConfiguration();
      // TODO --> reload the list of configurations
      // TODO --> try to load it back in and load in the correct functions based on DataParameterCollections
    }

    private void ApplyConfigurationDirectory(string file)
    {
      if (Directory.Exists(file))
      {
        this.ConfigurationDirectory = file;
        IList<string> configFiles = Directory.GetFiles(file).ToList();
      }
    }

    private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationCreationModel.SelectedDataType):
          this.SelectedDataType = Enum.GetName(typeof(StatType), this.configurationCreationModel.SelectedDataType);
          break;
        default:
          break;
      }
    }
  }
}
