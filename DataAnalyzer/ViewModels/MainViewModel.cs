using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels
{
    internal class MainViewModel : BasePropertyChanged
    {
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        public MainViewModel()
        {
            this.LoadedConfigs.Add(new LoadedConfigurationItemViewModel { Title = this.mainModel.LoadedInputFiles.Name });
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedInputFiles.DirectoryPathKeyValue);
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedInputFiles.DataTypeKeyValue);

            this.LoadedConfigs.Add(new LoadedConfigurationItemViewModel { Title = this.mainModel.LoadedDataStructure.Name });
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedDataStructure.DirectoryPathKeyValue);
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedDataStructure.StructureNameKeyValue);
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedDataStructure.DataTypeKeyValue);
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedDataStructure.ExportTypeKeyValue);
            this.LoadedConfigs.Last().ConfigData.Add(this.mainModel.LoadedDataStructure.GroupingsKeyValue);

            this.LoadedConfigs.Add(new LoadedConfigurationItemViewModel { Title = this.mainModel.LoadedDataContent.Name });

            this.mainModel.LoadedInputFiles.PropertyChanged += this.LoadedInputFilesPropertyChanged;
            this.mainModel.LoadedDataStructure.PropertyChanged += this.LoadedDataStructurePropertyChanged;
            this.mainModel.LoadedDataContent.PropertyChanged += this.LoadedDataContentPropertyChanged;
        }

        public ObservableCollection<LoadedConfigurationItemViewModel> LoadedConfigs { get; } = new();

        private void UpdateLoadedConfigs(string name, string key, string keyValue)
        {
            foreach (LoadedConfigurationItemViewModel loadedConfig in this.LoadedConfigs)
            {
                if (loadedConfig.Title.Equals(name))
                {
                    for (int i = 0; i < loadedConfig.ConfigData.Count; i++)
                    {
                        if (loadedConfig.ConfigData[i].StartsWith(key))
                        {
                            loadedConfig.ConfigData[i] = keyValue;
                        }
                    }
                }
            }
        }

        private void LoadedInputFilesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.LoadedInputFiles.DirectoryPathKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedInputFiles.Name,
                      this.mainModel.LoadedInputFiles.DirectoryPathKey,
                      this.mainModel.LoadedInputFiles.DirectoryPathKeyValue);
                    break;
                case nameof(this.mainModel.LoadedInputFiles.DataTypeKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedInputFiles.Name,
                      this.mainModel.LoadedInputFiles.DataTypeKey,
                      this.mainModel.LoadedInputFiles.DataTypeKeyValue);
                    break;
            }
        }

        private void LoadedDataStructurePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.LoadedDataStructure.DirectoryPathKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedDataStructure.Name,
                      this.mainModel.LoadedDataStructure.DirectoryPathKey,
                      this.mainModel.LoadedDataStructure.DirectoryPathKeyValue);
                    break;
                case nameof(this.mainModel.LoadedDataStructure.StructureNameKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedDataStructure.Name,
                      this.mainModel.LoadedDataStructure.StructureNameKey,
                      this.mainModel.LoadedDataStructure.StructureNameKeyValue);
                    break;
                case nameof(this.mainModel.LoadedDataStructure.DataTypeKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedDataStructure.Name,
                      this.mainModel.LoadedDataStructure.DataTypeKey,
                      this.mainModel.LoadedDataStructure.DataTypeKeyValue);
                    break;
                case nameof(this.mainModel.LoadedDataStructure.ExportTypeKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedDataStructure.Name,
                      this.mainModel.LoadedDataStructure.ExportTypeKey,
                      this.mainModel.LoadedDataStructure.ExportTypeKeyValue);
                    break;
                case nameof(this.mainModel.LoadedDataStructure.GroupingsKeyValue):
                    this.UpdateLoadedConfigs(
                      this.mainModel.LoadedDataStructure.Name,
                      this.mainModel.LoadedDataStructure.GroupingsKey,
                      this.mainModel.LoadedDataStructure.GroupingsKeyValue);
                    break;
            }
        }

        private void LoadedDataContentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //switch (e.propertyName)
            //{
            //}
        }
    }
}
