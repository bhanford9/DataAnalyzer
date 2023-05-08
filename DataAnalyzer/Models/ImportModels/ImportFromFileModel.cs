using DataAnalyzer.Services;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DataAnalyzer.Models.ImportModels
{
    internal class ImportFromFileModel : ImportModel, IImportFromFileModel
    {
        private static string FILE_IMPORT_DIRECTORY = "FileImport";
        private static string FILE_IMPORT_MAPPING_FILE = "DirectoryMappings.json";

        private readonly IFileMap fileMap;
        private readonly ISerializationService serializer;

        public ImportFromFileModel(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            ISerializationService serializationService)
            : base(configurationModel, mainModel)
        {
            this.serializer = serializationService;
            this.ActiveDirectory = Properties.Settings.Default.LastUsedDataDirectory;

            this.fileMap = this.GetFileImportMappings();

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
                this.GetFileImportMappings();
            }

            this.fileMap.MapFile(this.configurationModel.ImportExecutionKey.ImportKey, path);
            this.UpdateFileImportMappings(this.fileMap);
        }

        public void ApplyActiveDirectory(IImportType import, IScraperCategory category, IScraperFlavor flavor)
        {
            if (this.fileMap.TryGetData(import, category, flavor, out string file))
            {
                this.ApplyActiveDirectory(file);
            }
        }

        public void ApplyActiveDirectory(ImportKey key) => this.ApplyActiveDirectory(key.Type, key.Category, key.Flavor);

        private void UpdateFileImportMappings(IFileMap fileMap)
        {
            string mappingFile = this.GetFileImportAppConfigPath();
            Directory.CreateDirectory(Path.GetDirectoryName(mappingFile));
            this.serializer.JsonSerializeToFile(fileMap.ToSerializable(), mappingFile);
        }

        private IFileMap GetFileImportMappings()
        {
            string mappingFile = this.GetFileImportAppConfigPath();

            if (File.Exists(mappingFile))
            {
                var result = this.serializer.JsonDeserializeFromFile<List<KeyValuePair<IImportType, List<KeyValuePair<IScraperCategory, List<KeyValuePair<IScraperFlavor, string>>>>>>>(mappingFile);
                var fileMap = new FileMap();
                fileMap.FromSerializable(result);
                return fileMap;
            }

            return new FileMap();
        }

        private void ConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportExecutionKey):
                    this.ApplyActiveDirectory(this.configurationModel.ImportExecutionKey.ImportKey);
                    break;
            }
        }

        private string GetFileImportAppConfigPath()
            => Path.Combine(
                this.configurationModel.ConfigurationDirectory,
                FILE_IMPORT_DIRECTORY,
                FILE_IMPORT_MAPPING_FILE);
    }
}
