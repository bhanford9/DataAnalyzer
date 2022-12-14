using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class ExcelConfigurationModel : BasePropertyChanged
    {
        private const string DATA_TYPE_CONFIG_FILE_NAME = "DataTypesConfiguration.cfg.json";
        private const string WORKBOOK_CONFIG_PATH_KEY = "WorkbookConfigs";
        private const string DATA_TYPES_CONFIG_PATH_KEY = "DataTypeConfigs";

        private readonly SerializationService serializationService = new SerializationService();
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
        private ICollection<WorkbookModel> workbookModels = new List<WorkbookModel>();

        private string configurationDirectory = string.Empty;
        private string dataTypeConfigName = string.Empty;
        private string dataTypeConfigPath = string.Empty;
        private string workbookConfigName = string.Empty;
        private string workbookOutputDirectory = string.Empty;

        private IList<ITypeParameter> loadedParameterTypes = new List<ITypeParameter>();
        private readonly ICollection<LastSavedConfiguration> lastSavedDataTypeConfigs = new List<LastSavedConfiguration>();

        public ExcelConfigurationModel()
        {
            this.ConfigurationDirectory = Properties.Settings.Default.LastUsedExcelConfigurationDirectory;
            this.WorkbookOutputDirectory = Properties.Settings.Default.LastUsedExcelOutputDirectory;

            string configFilePath = this.GetDataTypeConfigPath();

            if (File.Exists(configFilePath))
            {
                this.lastSavedDataTypeConfigs = this.serializationService.JsonDeserializeFromFile<ICollection<LastSavedConfiguration>>(configFilePath);

                if (this.configurationModel.SelectedDataType != StatType.NotApplicable)
                {
                    string dataTypeConfigPath = this.GetCurrentDataTypeConfigDirectoryPath();
                    this.LoadDataTypeConfigByPath(dataTypeConfigPath);
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
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                Properties.Settings.Default.LastUsedExcelConfigurationDirectory = value;
                Properties.Settings.Default.Save();
            }
        }

        public ICollection<WorkbookModel> WorkbookModels
        {
            get => this.workbookModels;
            set => this.NotifyPropertyChanged(ref this.workbookModels, value);
        }

        public string DataTypeConfigName
        {
            get => this.dataTypeConfigName;
            set => this.NotifyPropertyChanged(ref this.dataTypeConfigName, value);
        }

        public string DataTypeConfigurationPath
        {
            get => this.dataTypeConfigPath;
            set => this.NotifyPropertyChanged(ref this.dataTypeConfigPath, value);
        }

        public string WorkbookConfigName
        {
            get => this.workbookConfigName;
            set => this.NotifyPropertyChanged(ref this.workbookConfigName, value);
        }

        public string WorkbookOutputDirectory
        {
            get => this.workbookOutputDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.workbookOutputDirectory, value);
                Properties.Settings.Default.LastUsedExcelOutputDirectory = value;
                Properties.Settings.Default.Save();
            }
        }

        public IList<ITypeParameter> LoadedParameterTypes
        {
            get => this.loadedParameterTypes;
            set => this.NotifyPropertyChanged(ref this.loadedParameterTypes, value);
        }

        public void ApplyTypeParametersToConfig(IList<ITypeParameter> typeParams)
        {
            this.LoadedParameterTypes.Clear();
            typeParams.ToList().ForEach(x => this.LoadedParameterTypes.Add(x));
            this.NotifyPropertyChanged(nameof(this.LoadedParameterTypes));
        }

        public void ApplyWorkbooksOutputPath(string path)
        {
            foreach (WorkbookModel workbookModel in this.workbookModels)
            {
                workbookModel.FilePath = path + "\\" + workbookModel.Name + FileProperties.EXCEL_WORKBOOK_FILE_EXTENSION;
            }
        }

        public void LoadDataTypeConfigByName(string configName)
        {
            string filePath = this.GetCurrentDataTypeConfigDirectoryPath() + "\\" + configName + FileProperties.EXCEL_CONFIG_FILE_EXTENSION;
            this.LoadDataTypeConfigByPath(filePath);
        }

        public void LoadDataTypeConfigByPath(string configPath)
        {
            if (File.Exists(configPath))
            {
                IList<ITypeParameter> loadedParams = this.serializationService.JsonDeserializeFromFile<IList<ITypeParameter>>(configPath);
                foreach (ITypeParameter parameter in loadedParams)
                {
                    // this is complicated (ugly)... We have static possibilities of excel data types and we build up an
                    // example and format string for these classes. We save other related metadata to configuraiton files.
                    // These are separate, but also joined in a messay way, so I create the excel part of the object and then
                    // copy in the saved metadata.
                    this.LoadedParameterTypes.Add(this.excelDataTypeLibrary.GetInstanceByName(parameter.ExcelTypeName));
                    this.LoadedParameterTypes[^1].CloneParameters(parameter);
                }

                this.NotifyPropertyChanged(nameof(this.LoadedParameterTypes));

                string fileName = Path.GetFileName(configPath);
                this.DataTypeConfigName = fileName[..fileName.IndexOf('.')];

                if (!string.IsNullOrEmpty(this.configurationModel.DataConfiguration.SavedDataFilePath))
                {
                    this.LoadWorkbookConfigByPath(this.configurationModel.DataConfiguration.SavedDataFilePath);
                }
            }
        }

        public void SaveDataTypeConfiguration(IList<ITypeParameter> parameters, string configName)
        {
            string directoryPath = this.GetCurrentDataTypeConfigDirectoryPath();
            string filePath = directoryPath + "\\" + configName + FileProperties.EXCEL_DATA_TYPE_CONFIG_FILE_EXTENSION;

            this.LoadedParameterTypes.Clear();
            parameters.ToList().ForEach(x => this.LoadedParameterTypes.Add(x));
            this.serializationService.JsonSerializeToFile(this.LoadedParameterTypes, filePath);

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

        public void LoadWorkbookConfigByName(string configName)
        {
            string filePath = this.GetCurrentWorkbookConfigDirectoryPath() + "\\" + configName + FileProperties.EXCEL_CONFIG_FILE_EXTENSION;
            this.LoadWorkbookConfigByPath(filePath);
        }

        public void LoadWorkbookConfigByPath(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.WorkbookModels = this.serializationService.JsonDeserializeFromFile<ICollection<WorkbookModel>>(filePath);
                this.WorkbookConfigName = Path.GetFileNameWithoutExtension(filePath);
                while (this.WorkbookConfigName.Contains("."))
                {
                    this.WorkbookConfigName = Path.GetFileNameWithoutExtension(this.WorkbookConfigName);
                }
            }
        }

        public void SaveWorkbookConfiguration(string configName)
        {
            string directoryPath = this.GetCurrentWorkbookConfigDirectoryPath();
            string filePath = directoryPath + "\\" + configName + FileProperties.EXCEL_CONFIG_FILE_EXTENSION;

            this.serializationService.JsonSerializeToFile(this.workbookModels, filePath);

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

        public string GetDataTypeConfigPath()
        {
            return this.configurationDirectory + "\\" + DATA_TYPE_CONFIG_FILE_NAME;
        }

        public string GetCurrentDataTypeConfigDirectoryPath()
        {
            return this.configurationDirectory + "\\" + this.configurationModel.SelectedDataType.ToString() + "\\" + DATA_TYPES_CONFIG_PATH_KEY;
        }

        public string GetCurrentWorkbookConfigDirectoryPath()
        {
            return this.configurationDirectory + "\\" + this.configurationModel.SelectedDataType.ToString() + "\\" + WORKBOOK_CONFIG_PATH_KEY;
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
                        this.LoadDataTypeConfigByPath(lastSavedConfiguration.FilePath);
                    }
                    break;
            }
        }
    }
}
