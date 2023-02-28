using DataAnalyzer.Common.DataConverters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.Utilities;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ImportViewModels
{
    internal class ImportFromFileViewModel : ImportViewModel
    {
        private string activeDirectory = "No Directory Selected Yet";
        private string selectedScraperCategory = string.Empty;

        private readonly BaseCommand browseDirectory;
        private readonly BaseCommand importData;

        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly DataConverterLibrary dataConverterLibrary = new();

        //private IReadOnlyDictionary<Services.Enums.ScraperCategory, ConverterType> scraperToConverterMap;

        public ImportFromFileViewModel()
        {
            this.browseDirectory = new BaseCommand((object o) => this.DoBrowseDirectory());
            this.importData = new BaseCommand((object o) => this.DoImportData());

            this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;
            this.SelectedScraperCategory = Properties.Settings.Default.LastSelectedScraperType;

            if (this.ActiveDirectory != string.Empty)
            {
                this.ApplyActiveDirectory(this.ActiveDirectory);
            }

            // TODO --> put into a class. Scraper Service could use similar tools
            //this.scraperToConverterMap = new Dictionary<Services.Enums.ScraperCategory, ConverterType>()
            //{
            //    { Services.Enums.ScraperCategory.Custom, ConverterType.Queryable },
            //    { Services.Enums.ScraperCategory.CsvNames, ConverterType.CsvNames },
            //    { Services.Enums.ScraperCategory.Csv, ConverterType.Csv }, // TODO --> this will need a sub dictionary (more reason to put in class)
            //};

            //this.EnumUtilities.LoadNames(typeof(ScraperCategory), this.ScraperCategories);

            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
        }

        public ObservableCollection<CheckableTreeViewItem> Files { get; } = new();

        //public IReadOnlyCollection<IScraperCategory> ScraperCategories => this.statsModel.ScraperCategories;

        public ICommand BrowseDirectory => this.browseDirectory;

        public ICommand ImportData => this.importData;

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

        private void DoImportData()
        {
            this.statsModel.ClearLoadedStats();

            this.FlattenFiles()
                .Where(x => x.IsChecked && !File.GetAttributes(x.Path).HasFlag(FileAttributes.Directory))
                .ToList()
                .ForEach(file => this.statsModel.LoadStatsFromSource(new FileDataSource(file.Path)));
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

        private void MainModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ScraperCategory):
                    this.SelectedScraperCategory = this.mainModel.ScraperCategory.ToString();
                    break;
            }
        }

    }
}
