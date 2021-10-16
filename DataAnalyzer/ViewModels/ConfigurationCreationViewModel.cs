using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
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
    private ConfigurationCreationModel configurationCreationModel = new ConfigurationCreationModel();

    private bool isCreating = false;
    private string configurationDirectory = string.Empty;
    private string configurationName = string.Empty;
    private string selectedDataType = string.Empty;
    private int groupingLayersCount = 0;

    private BaseCommand browseDirectory;
    private BaseCommand createConfiguration;
    private BaseCommand cancelChanges;
    private BaseCommand saveConfiguration;

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
    }

    public ICommand BrowseDirectory => this.browseDirectory;
    public ICommand CreateConfiguration => this.createConfiguration;
    public ICommand CancelChanges => this.cancelChanges;
    public ICommand SaveConfiguration => this.saveConfiguration;

    public ObservableCollection<string> DataTypes { get; set; } =
      new ObservableCollection<string>();

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
        Properties.Settings.Default.LastUsedConfigurationDirectory = value;
        Properties.Settings.Default.Save();
      }
    }

    public string ConfigurationName
    {
      get => this.configurationName;
      set => this.NotifyPropertyChanged(nameof(this.ConfigurationName), ref this.configurationName, value);
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
