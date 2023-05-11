using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels;

internal interface IExcelConfigurationModel : INotifyPropertyChanged
{
    string ConfigurationDirectory { get; set; }
    string DataTypeConfigName { get; set; }
    string DataTypeConfigurationPath { get; set; }
    IList<ITypeParameter> LoadedParameterTypes { get; set; }
    ObservableCollection<FilePathAndNamePair> SavedConfigurations { get; }
    string WorkbookConfigName { get; set; }
    ICollection<WorkbookModel> WorkbookModels { get; set; }
    string WorkbookOutputDirectory { get; set; }

    void ApplyTypeParametersToConfig(IList<ITypeParameter> typeParams);
    void ApplyWorkbooksOutputPath(string path);
    string GetCurrentDataTypeConfigDirectoryPath();
    string GetCurrentWorkbookConfigDirectoryPath();
    string GetDataTypeConfigPath();
    void LoadDataTypeConfigByName(string configName);
    void LoadDataTypeConfigByPath(string configPath);
    void LoadDataTypesFromConfig();
    void LoadWorkbookConfigByName(string configName);
    void LoadWorkbookConfigByPath(string filePath);
    void SaveDataTypeConfiguration(IList<ITypeParameter> parameters, string configName);
    void SaveWorkbookConfiguration(string configName);
}