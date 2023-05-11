using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels;

internal interface IClassCreationConfigurationModel : INotifyPropertyChanged
{
    IClassesData ClassesData{ get; set; }
    string ConfigurationDirectory { get; set; }
    ICollection<string> Configurations { get; set; }
    string CurrentConfigName { get; set; }

    void AcquireConfigurations();
    string GetCurrentConfigDirectoryPath();
    void LoadConfigByName(string configName);
    void LoadConfigurationByPath(string filePath);
    void SaveWorkingConfiguration(string configName);
}