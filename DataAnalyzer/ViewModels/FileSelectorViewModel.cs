using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Forms;
using DataAnalyzer.Common.Mvvm;
using System.IO;
using System.Linq;
using DataAnalyzer.Models;
using System;
using DataAnalyzer.Common.DataConverters;
using System.Collections.Generic;
using DataAnalyzer.Services;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataConfigurations.ExcelConfiguration;
using DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats;

namespace DataAnalyzer.ViewModels
{
  public class FileSelectorViewModel : BasePropertyChanged
  {
    private string activeDirectory = "No Directory Selected Yet";
    private string selectedScraperType = string.Empty;

    private readonly BaseCommand browseDirectory;
    private readonly BaseCommand loadStats;

    private readonly StatsModel statsModel = new StatsModel();
    private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
    private readonly DataConverterLibrary dataConverterLibrary = new DataConverterLibrary();

    public FileSelectorViewModel()
    {
      this.browseDirectory = new BaseCommand((object o) => this.DoBrowseDirectory());
      this.loadStats = new BaseCommand((object o) => this.DoLoadStats());

      this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;
      this.SelectedScraperType = Properties.Settings.Default.LastSelectedScraperType;

      if (this.ActiveDirectory != string.Empty)
      {
        this.ApplyActiveDirectory(this.ActiveDirectory);
      }

      Enum.GetNames(typeof(ScraperType)).ToList().ForEach(x => this.ScraperTypes.Add(x));
    }

    public ObservableCollection<CheckableTreeViewItem> Files { get; }
      = new ObservableCollection<CheckableTreeViewItem>();

    public ObservableCollection<string> ScraperTypes { get; }
      = new ObservableCollection<string>();

    public ICommand BrowseDirectory => this.browseDirectory;

    public ICommand LoadStats => this.loadStats;

    public string ActiveDirectory
    {
      get => this.activeDirectory;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ActiveDirectory), ref this.activeDirectory, value);
        this.mainModel.LoadedInputFiles.DirectoryPath = value;
      }
    }

    public string SelectedScraperType
    {
      get => this.selectedScraperType;
      set
      {
        this.NotifyPropertyChanged(nameof(this.SelectedScraperType), ref this.selectedScraperType, value);
        this.mainModel.LoadedInputFiles.DataType = value;

        Properties.Settings.Default.LastSelectedScraperType = value;
        Properties.Settings.Default.Save();
      }
    }

    private void DoBrowseDirectory()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        this.ApplyActiveDirectory(folderBrowserDialog.SelectedPath);
      }
    }

    private void DoLoadStats()
    {
      this.statsModel.ClearLoadedStats();

      this.FlattenFiles()
        .Where(x => x.IsChecked && !File.GetAttributes(x.Path).HasFlag(FileAttributes.Directory))
        .ToList()
        .ForEach(file =>
      {
        ConverterType currentType = Enum.Parse<ConverterType>(this.selectedScraperType);
        IDataConverter converter = this.dataConverterLibrary.GetConverter(currentType);
        this.statsModel.LoadStatsForFile(file.Path, converter);
      });

      ExcelConfiguration configuration = new ExcelConfiguration();
      configuration.AddGroupingRule(0, (stats) => (stats as QueryableTimeStats).MethodName);
      configuration.AddGroupingRule(1, (stats) => (stats as QueryableTimeStats).ContainerType);
      configuration.AddGroupingRule(2, (stats) => (stats as QueryableTimeStats).CategoryType);

      DataOrganizer organizer = new DataOrganizer();
      organizer.Organize(configuration, this.statsModel.Stats);
    }

    private ICollection<CheckableTreeViewItem> FlattenFiles()
    {
      ICollection<CheckableTreeViewItem> flattenedFiles = new List<CheckableTreeViewItem>();
      this.AddChildren(this.Files.First(), flattenedFiles);
      return flattenedFiles;
    }

    private void AddChildren(CheckableTreeViewItem root, ICollection<CheckableTreeViewItem> flattenedFiles)
    {
      flattenedFiles.Add(root);
      root.Children.ToList().ForEach(x => this.AddChildren(x, flattenedFiles));
    }

    private void ApplyActiveDirectory(string path)
    {
      this.ActiveDirectory = path;

      this.Files.Clear();

      this.Files.Add(new CheckableTreeViewItem()
      {
        Path = this.ActiveDirectory,
        Name = Path.GetFileName(this.ActiveDirectory)
      });

      this.LoadAllChildren(this.ActiveDirectory, this.Files[0]);

      Properties.Settings.Default.LastUsedDataDirectory = this.ActiveDirectory;
      Properties.Settings.Default.Save();
    }

    private void LoadAllChildren(string pathRoot, CheckableTreeViewItem treeRoot)
    {
      try
      {
        foreach (string file in Directory.GetFiles(pathRoot))
        {
          treeRoot.Children.Add(
            new CheckableTreeViewItem()
            {
              Path = file,
              Name = Path.GetFileName(file)
            });
        }
      }
      catch { }

      try
      {
        foreach (string directory in Directory.GetDirectories(pathRoot))
        {
          treeRoot.Children.Add(
            new CheckableTreeViewItem()
            {
              Path = directory,
              Name = Path.GetFileName(directory)
            });

          this.LoadAllChildren(directory, treeRoot.Children[^1]);
        }
      }
      catch { }
    }
  }
}
