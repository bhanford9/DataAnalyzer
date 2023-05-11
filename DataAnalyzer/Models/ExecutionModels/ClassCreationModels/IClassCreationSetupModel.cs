using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels;

internal interface IClassCreationSetupModel : INotifyPropertyChanged
{
    IClassCreationConfigurationModel ClassCreationConfigModel { get; }
    string ConfigurationName { get; set; }
    ICollection<IClassData> DataItems { get; }

    string GetClassesString(ICollection<IClassData> classes);
    void LoadDataFromConfiguration();
}