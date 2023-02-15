using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using DataAnalyzer.Services;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels
{
    // This class acts as the conductor for getting data in/out of serialized form.
    // This class is not meant to be the thing being [de]serialized
    //
    // This has started to feel like there could be an abstract ConfigurationModel class that takes its
    //   DTO as a type parameter and then many of the required methods could be made abstract and work similarly
    //   to the other layers
    // The more I go, the more duplicate code I am seeing, so this is going to be more desirable
    internal class ClassCreationConfigurationModel : BasePropertyChanged
    {
        private const string CLASS_CREATION_KEY = "ClassCreation";

        private readonly SerializationService serializationService = new();
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        private string configurationDirectory = string.Empty;
        private string currentConfigName = string.Empty;

        private ClassProperties classProperties = new();

        public ClassCreationConfigurationModel()
        {
            ConfigurationDirectory = Properties.Settings.Default.LastUsedClassCreationConfigurationDirectory;
        }

        public ICollection<string> Configurations { get; set; } = new List<string>();

        public string ConfigurationDirectory
        {
            get => configurationDirectory;
            set
            {
                NotifyPropertyChanged(ref configurationDirectory, value);
                Properties.Settings.Default.LastUsedClassCreationConfigurationDirectory = value;
                Properties.Settings.Default.Save();
                this.AcquireConfigurations();
            }
        }

        public ClassProperties ClassProperties
        {
            get => this.classProperties;
            set => this.NotifyPropertyChanged(ref this.classProperties, value);
        }

        public string CurrentConfigName
        {
            get => this.currentConfigName;
            set => this.NotifyPropertyChanged(ref this.currentConfigName, value);
        }

        public void LoadConfigByName(string configName)
        {
            string directoryPath = this.GetCurrentConfigDirectoryPath();
            string filePath = directoryPath + "\\" + configName + FileProperties.JSON_FILE_EXTENSION;
            this.LoadConfigurationByPath(filePath);
        }

        public void LoadConfigurationByPath(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.ClassProperties = this.serializationService.JsonDeserializeFromFile<ClassProperties>(filePath);
                this.CurrentConfigName = Path.GetFileNameWithoutExtension(filePath);

                while (this.CurrentConfigName.Contains('.'))
                {
                    this.CurrentConfigName = Path.GetFileNameWithoutExtension(this.CurrentConfigName);
                }
            }
        }

        public void SaveWorkingConfiguration(string configName)
        {
            string directoryPath = this.GetCurrentConfigDirectoryPath();
            string filePath = directoryPath + "\\" + configName + FileProperties.JSON_FILE_EXTENSION;

            this.serializationService.JsonSerializeToFile(this.ClassProperties, filePath);

            this.configurationModel.SavedDataFilePath = filePath;

            this.AcquireConfigurations();
        }

        public string GetCurrentConfigDirectoryPath() =>
            this.configurationDirectory + "\\" + this.configurationModel.SelectedDataType.ToString() + "\\" + CLASS_CREATION_KEY;

        public void AcquireConfigurations()
        {
            this.Configurations = Directory
                .GetFiles(this.GetCurrentConfigDirectoryPath())
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .ToList();
        }
    }
}
