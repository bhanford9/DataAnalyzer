using DataAnalyzer.Common.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
  public class ConfigurationCreationViewModel : BasePropertyChanged
  {
    private const string CONFIGURATION_FILE_EXTENSION = ".dacfg";

    private bool isCreating = false;
    private string configurationDirectory = string.Empty;
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
    }

    public ICommand BrowseDirectory => this.browseDirectory;
    public ICommand CreateConfiguration => this.createConfiguration;
    public ICommand CancelChanges => this.cancelChanges;
    public ICommand SaveConfiguration => this.saveConfiguration;

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

    public bool IsCreating
    {
      get => this.isCreating;
      set => this.NotifyPropertyChanged(nameof(this.IsCreating), ref this.isCreating, value);
    }

    public int GroupingLayersCount
    {
      get => this.groupingLayersCount;
      set => this.NotifyPropertyChanged(nameof(this.GroupingLayersCount), ref this.groupingLayersCount, value);
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
    }

    private void DoCancelChanges()
    {
      this.IsCreating = false;
    }

    private void DoSaveConfiguration()
    {

    }

    private void ApplyConfigurationDirectory(string file)
    {
      if (Directory.Exists(file))
      {
        this.ConfigurationDirectory = file;
        IList<string> configFiles = Directory.GetFiles(file).ToList();
      }
    }
  }
}
