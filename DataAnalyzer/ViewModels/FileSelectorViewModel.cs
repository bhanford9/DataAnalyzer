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
using DataAnalyzer.ViewModels.Utilities;
using DataScraper.DataScrapers.ScraperCategories;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataSources;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.ViewModels
{
    // TODO --> remove this file
    internal class FileSelectorViewModel : BasePropertyChanged
    {
        private string activeDirectory = "No Directory Selected Yet";
        private string selectedScraperCategory = string.Empty;

        private readonly BaseCommand browseDirectory;
        private readonly BaseCommand loadStats;

        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        public FileSelectorViewModel()
        {
            this.browseDirectory = new BaseCommand((object o) => this.DoBrowseDirectory());
            this.loadStats = new BaseCommand((object o) => this.DoLoadStats());

            this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;
            this.SelectedScraperCategory = Properties.Settings.Default.LastSelectedScraperType;

            if (this.ActiveDirectory != string.Empty)
            {
                this.ApplyActiveDirectory(this.ActiveDirectory);
            }

            //this.EnumUtilities.LoadNames(typeof(ScraperCategory), this.ScraperCategories);
        }

        public ObservableCollection<CheckableTreeViewItem> Files { get; } = new();

        //public IReadOnlyCollection<IScraperCategory> ScraperCategories => this.statsModel.ScraperCategories;

        public ICommand BrowseDirectory => this.browseDirectory;

        public ICommand LoadStats => this.loadStats;

        public string ActiveDirectory
        {
            get => this.activeDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.activeDirectory, value);
                this.mainModel.LoadedInputFiles.DirectoryPath = value;
            }
        }

        public string SelectedScraperCategory
        {
            get => this.selectedScraperCategory;
            set
            {
                this.mainModel.LoadedInputFiles.DataType = value;
                this.NotifyPropertyChanged(ref this.selectedScraperCategory, value);

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
            //this.statsModel.ClearLoadedStats();

            //// TODO --> this is assuming file import. need to make this capable of supporting other data import types
            //this.FlattenFiles()
            //    .Where(x => x.IsChecked && !File.GetAttributes(x.Path).HasFlag(FileAttributes.Directory))
            //    .ToList()
            //    .ForEach(file =>
            //    {
            //        //ConverterType currentType = this.scraperToConverterMap[Enum.Parse<Services.Enums.ScraperCategory>(this.selectedScraperCategory)];
            //        //IDataConverter converter = this.dataConverterLibrary.GetConverter(currentType);

            //        IScraperCategory category = null;
            //        IScraperFlavor flavor = null;

            //        // UI has 1-to-1 mapping with IDataSource and IScraperCategory
            //        // IDataConverter maps to IScraperCategory & IScraperFlavor combo (model conversion)

            //        // in order to call this, we need to map the selected UI combo boxes down to some dictionaries
            //        // that give us the correct interfaces
            //        this.statsModel.LoadStatsFromSource(new FileDataSource(file.Path), new FileImportType(), category, flavor);
            //    });
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

            this.Files.Add(new CheckableTreeViewItem
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
                      new CheckableTreeViewItem
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
                      new CheckableTreeViewItem
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
