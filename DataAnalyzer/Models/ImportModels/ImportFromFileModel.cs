using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.Models.ImportModels
{
    internal class ImportFromFileModel : ImportModel
    {
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly FileMap fileMap = new();

        public ImportFromFileModel()
        {
            this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;
            
            this.fileMap = this.configurationModel.GetFileImportMappings();

            if (this.ActiveDirectory != string.Empty)
            {
                this.ApplyActiveDirectory(this.ActiveDirectory);
            }

            this.configurationModel.PropertyChanged += this.ConfigModelPropertyChanged;
        }

        public string ActiveDirectory { get; private set; } = "No Directory Selected Yet";

        public void ApplyActiveDirectory(string path)
        {
            this.ActiveDirectory = path;
            this.NotifyPropertyChanged(nameof(ActiveDirectory));
            this.mainModel.LoadedInputFiles.DirectoryPath = path;

            Properties.Settings.Default.LastUsedDataDirectory = this.ActiveDirectory;
            Properties.Settings.Default.Save();

            if (!this.fileMap.Keys.Any())
            {
                this.configurationModel.GetFileImportMappings();
            }

            this.fileMap.MapFile(this.configurationModel.ImportExportKey.ImportKey, path);
            this.configurationModel.UpdateFileImportMappings(this.fileMap);
        }

        public void ApplyActiveDirectory(IImportType import, IScraperCategory category, IScraperFlavor flavor)
        {
            if (this.fileMap.TryGetData(import, category, flavor, out string file))
            {
                this.ApplyActiveDirectory(file);
            }
        }

        public void ApplyActiveDirectory(ImportKey key) => this.ApplyActiveDirectory(key.Type, key.Category, key.Flavor);

        private void ConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportExportKey):
                    this.ApplyActiveDirectory(this.configurationModel.ImportExportKey.ImportKey);
                    break;
            }
        }
    }
}
