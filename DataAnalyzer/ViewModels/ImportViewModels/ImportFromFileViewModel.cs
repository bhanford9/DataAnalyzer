﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ImportModels;
using DataAnalyzer.ViewModels.Utilities;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ImportViewModels
{
    internal class ImportFromFileViewModel : ImportViewModel
    {
        private string activeDirectory = string.Empty;

        private readonly BaseCommand browseDirectory;
        private readonly BaseCommand importData;

        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly ImportFromFileModel importModel = BaseSingleton<ImportFromFileModel>.Instance;

        protected override IImportModel ImportModel => importModel;

        public ImportFromFileViewModel()
        {
            this.browseDirectory = new BaseCommand((object o) => this.DoBrowseDirectory());
            this.importData = new BaseCommand((object o) => this.DoImportData());
            
            this.ActiveDirectory = this.importModel.ActiveDirectory;
            this.importModel.PropertyChanged += this.ImportModelPropertyChanged;
        }

        public ObservableCollection<CheckableTreeViewItem> Files { get; } = new();

        public ICommand BrowseDirectory => this.browseDirectory;

        public ICommand ImportData => this.importData;

        public string ActiveDirectory
        {
            get => this.activeDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.activeDirectory, value);

                this.Files.Clear();

                this.Files.Add(new CheckableTreeViewItem
                {
                    Path = this.ActiveDirectory,
                    Name = Path.GetFileName(this.ActiveDirectory)
                });

                this.LoadAllChildren(this.ActiveDirectory, this.Files[0]);
            }
        }

        private void DoBrowseDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.importModel.ApplyActiveDirectory(folderBrowserDialog.SelectedPath);
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

        private void ImportModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.importModel.ActiveDirectory):
                    this.ActiveDirectory = this.importModel.ActiveDirectory;
                    break;
            }
        }
    }
}
