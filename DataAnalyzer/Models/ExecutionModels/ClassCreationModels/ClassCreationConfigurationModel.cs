using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using DataAnalyzer.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels;

// This class acts as the conductor for getting data in/out of serialized form.
// This class is not meant to be the thing being [de]serialized
//
// This has started to feel like there could be an abstract ConfigurationModel class that takes its
//   DTO as a type parameter and then many of the required methods could be made abstract and work similarly
//   to the other layers
// The more I go, the more duplicate code I am seeing, so this is going to be more desirable
internal class ClassCreationConfigurationModel : BasePropertyChanged, IClassCreationConfigurationModel
{
    private const string CLASS_CREATION_KEY = "ClassCreation";

    private readonly ISerializationService serializationService;
    private readonly IConfigurationModel configurationModel;

    private string configurationDirectory = string.Empty;
    private string currentConfigName = string.Empty;

    private IClassesData classesData = new ClassesData();

    public ClassCreationConfigurationModel(
        ISerializationService serializationService,
        IConfigurationModel configurationModel)
    {
        this.serializationService = serializationService;
        this.configurationModel = configurationModel;
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

    public IClassesData ClassesData
    {
        get => this.classesData;
        set => this.NotifyPropertyChanged(ref this.classesData, value);
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
            this.ClassesData = this.serializationService.JsonDeserializeFromFile<ClassesData>(filePath);
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

        this.serializationService.JsonSerializeToFile(this.ClassesData, filePath);

        this.configurationModel.SavedDataFilePath = filePath;

        this.AcquireConfigurations();
    }

    public string GetCurrentConfigDirectoryPath() =>
        this.configurationDirectory + "\\" + this.configurationModel.ImportExecutionKey.Name + "\\" + CLASS_CREATION_KEY;

    public void AcquireConfigurations()
    {
        try
        {
            this.Configurations = Directory
                .GetFiles(this.GetCurrentConfigDirectoryPath())
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .ToList();
        }
        catch
        { // TODO
        }
    }
}
