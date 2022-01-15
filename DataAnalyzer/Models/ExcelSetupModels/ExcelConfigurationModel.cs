﻿using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations;
using DataAnalyzer.Services.Serializations.ExcelSerializations;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataAnalyzer.ViewModels.Utilities;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelConfigurationModel : BasePropertyChanged
  {
    private const string DATA_TYPE_CONFIG_FILE_NAME = "DataTypesConfiguration.cfg.json";
    private const string WORKBOOK_CONFIG_PATH_KEY = "WorkbookConfigs";
    private const string DATA_TYPES_CONFIG_PATH_KEY = "DataTypeConfigs";

    private readonly SerializationService serializationService = new SerializationService();
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private ICollection<WorkbookModel> workbookModels = new List<WorkbookModel>();

    private string configurationDirectory = string.Empty;
    private string configurationName = string.Empty;
    private string dataTypeConfigurationPath = string.Empty;

    private ExcelDataTypesSerialization loadedParameterTypes = new ExcelDataTypesSerialization();
    private readonly ICollection<LastSavedConfiguration> lastSavedDataTypeConfigs = new List<LastSavedConfiguration>();

    public ExcelConfigurationModel()
    {
      this.ConfigurationDirectory = Properties.Settings.Default.LastUsedExcelConfigurationDirectory;

      string configFilePath = this.GetDataTypeConfigPath();

      if (File.Exists(configFilePath))
      {
        this.lastSavedDataTypeConfigs = this.serializationService.JsonDeserializeFromFile<ICollection<LastSavedConfiguration>>(configFilePath);

        if (this.configurationModel.SelectedDataType != StatType.NotApplicable)
        {
          string dataTypeConfigPath = this.GetCurrentDataTypeConfigDirectoryPath();
          this.LoadConfigurationByPath(dataTypeConfigPath);
        }
      }

      this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
    }

    public ObservableCollection<FilePathAndNamePair> SavedConfigurations { get; }
      = new ObservableCollection<FilePathAndNamePair>();

    public string ConfigurationDirectory
    {
      get => this.configurationDirectory;
      set
      {
        this.NotifyPropertyChanged(nameof(this.ConfigurationDirectory), ref this.configurationDirectory, value);
        Properties.Settings.Default.LastUsedExcelConfigurationDirectory = value;
        Properties.Settings.Default.Save();
      }
    }

    public ICollection<WorkbookModel> WorkbookModels
    {
      get => this.workbookModels;
      set => this.NotifyPropertyChanged(nameof(this.WorkbookModels), ref this.workbookModels, value);
    }

    public string ConfigurationName
    {
      get => this.configurationName;
      set => this.NotifyPropertyChanged(nameof(this.ConfigurationName), ref this.configurationName, value);
    }

    public string DataTypeConfigurationPath
    {
      get => this.dataTypeConfigurationPath;
      set => this.NotifyPropertyChanged(nameof(this.DataTypeConfigurationPath), ref this.dataTypeConfigurationPath, value);
    }

    public ExcelDataTypesSerialization LoadedParameterTypes
    {
      get => this.loadedParameterTypes;
      set => this.NotifyPropertyChanged(nameof(this.LoadedParameterTypes), ref this.loadedParameterTypes, value);
    }

    public void LoadConfigurationByName(string configName)
    {
      string filePath = this.GetCurrentDataTypeConfigDirectoryPath() + "\\" + configName + FileProperties.EXCEL_CONFIG_FILE_EXTENSION;
      this.LoadConfigurationByPath(filePath);
    }

    public void LoadConfigurationByPath(string configPath)
    {
      if (File.Exists(configPath))
      {
        this.LoadedParameterTypes = this.serializationService.CustomDeserializeFromFile(configPath) as ExcelDataTypesSerialization;

        string fileName = Path.GetFileName(configPath);
        this.ConfigurationName = fileName.Substring(0, fileName.IndexOf('.'));

        if (!string.IsNullOrEmpty(this.configurationModel.DataConfiguration.SavedDataFilePath))
        {
          this.LoadWorkbookConfiguration(this.configurationModel.DataConfiguration.SavedDataFilePath);
        }
      }
    }

    public void SaveDataTypeConfiguration(ExcelDataTypesSerialization serializationCollection, string configName)
    {
      string directoryPath = this.GetCurrentDataTypeConfigDirectoryPath();
      string filePath = directoryPath + "\\" + configName + FileProperties.EXCEL_DATA_TYPE_CONFIG_FILE_EXTENSION;

      this.serializationService.CustomSerializeToFile(serializationCollection, filePath);

      bool found = false;
      foreach (LastSavedConfiguration config in this.lastSavedDataTypeConfigs)
      {
        if (config.StatType.Equals(this.configurationModel.SelectedDataType))
        {
          found = true;
          config.FilePath = filePath;
        }
      }

      if (!found)
      {
        this.lastSavedDataTypeConfigs.Add(new LastSavedConfiguration()
        {
          FilePath = filePath,
          StatType = this.configurationModel.SelectedDataType
        });
      }

      this.serializationService.JsonSerializeToFile(this.lastSavedDataTypeConfigs, this.GetDataTypeConfigPath());

      this.LoadDataTypesFromConfig();
    }

    public void SaveWorkbookConfiguration(string configName)
    {
      string directoryPath = this.GetCurrentWorkbookConfigDirectoryPath();
      string filePath = directoryPath + "\\" + configName + FileProperties.EXCEL_CONFIG_FILE_EXTENSION;


      SingleSerializationCollection<WorkbookModel, WorkbookSerialization> workbookSerializations =
        new SingleSerializationCollection<WorkbookModel, WorkbookSerialization>(this.workbookModels, "Workbooks");

      this.serializationService.CustomSerializeToFile(workbookSerializations, filePath);

      this.configurationModel.ApplyDataPath(filePath);
    }

    public void LoadDataTypesFromConfig()
    {
      this.SavedConfigurations.Clear();

      string directoryPath = this.GetCurrentDataTypeConfigDirectoryPath();
      Directory
        .GetFiles(directoryPath, $"*{FileProperties.EXCEL_DATA_TYPE_CONFIG_FILE_EXTENSION}")
        .ToList()
        .ForEach(x => this.SavedConfigurations.Add(new FilePathAndNamePair(x)));

      this.NotifyPropertyChanged(nameof(this.SavedConfigurations));
    }

    private string GetDataTypeConfigPath()
    {
      return this.configurationDirectory + "\\" + DATA_TYPE_CONFIG_FILE_NAME;
    }

    private string GetCurrentDataTypeConfigDirectoryPath()
    {
      return this.configurationDirectory + "\\" + this.configurationModel.SelectedDataType.ToString() + "\\" + DATA_TYPES_CONFIG_PATH_KEY;
    }

    private string GetCurrentWorkbookConfigDirectoryPath()
    {
      return this.configurationDirectory + "\\" + this.configurationModel.SelectedDataType.ToString() + "\\" + WORKBOOK_CONFIG_PATH_KEY;
    }

    private void LoadWorkbookConfiguration(string filePath)
    {
      if (File.Exists(filePath))
      {
        SingleSerializationCollection<WorkbookModel, WorkbookSerialization> workbookSerializations =
          (SingleSerializationCollection<WorkbookModel, WorkbookSerialization>)this.serializationService.CustomDeserializeFromFile(filePath);

        workbookSerializations.ApplyToValue();
        this.WorkbookModels = workbookSerializations.Items.Select(x => x.Value as WorkbookModel).ToList();
      }
    }

    private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationModel.SelectedDataType):
          LastSavedConfiguration lastSavedConfiguration = this.lastSavedDataTypeConfigs
            .FirstOrDefault(x => x.StatType.Equals(this.configurationModel.SelectedDataType));
          if (lastSavedConfiguration != default)
          {
            this.LoadDataTypesFromConfig();
            this.LoadConfigurationByPath(lastSavedConfiguration.FilePath);
          }
          break;
      }
    }
  }
}
