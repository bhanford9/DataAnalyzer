using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal abstract class DataStructureSetupModel<TDataConfiguration> : BasePropertyChanged, IDataStructureSetupModel<TDataConfiguration>
        where TDataConfiguration : IDataConfiguration, new()
    {
        protected readonly SerializationService serializationService = new();
        protected readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

        protected DataStructureSetupModel() { }

        public TDataConfiguration DataConfiguration { get; protected set; }

        public void LoadConfiguration(string configName)
        {
            string filePath = this.configurationModel.ConfigurationDirectory + "/" + configName + FileProperties.CONFIGN_FILE_EXTENSION;
            this.InitializeDataConfigFromFile(filePath);
            this.NotifyPropertyChanged(nameof(this.DataConfiguration));
        }

        public void SaveConfiguration()
        {
            DateTime saveTime = DateTime.Now;
            string saveUid = Guid.NewGuid().ToString();

            this.PrepareConfigurationForSaving(saveTime, saveUid);

            this.DataConfiguration.DateTime = saveTime;
            this.DataConfiguration.VersionUid = saveUid;
            this.DataConfiguration.StatType = this.configurationModel.SelectedDataType;
            this.DataConfiguration.ExportType = this.configurationModel.SelectedExportType;

            string fullFilePath = this.configurationModel.ConfigurationDirectory + "\\" + 
                this.configurationModel.ConfigurationName + FileProperties.CONFIGN_FILE_EXTENSION;
            this.serializationService.JsonSerializeToFile(this.DataConfiguration, fullFilePath);
        }

        public void CreateNewDataConfiguration() => this.DataConfiguration = new TDataConfiguration();//this.NotifyPropertyChanged(nameof(this.DataConfiguration));

        protected abstract void PrepareConfigurationForSaving(DateTime saveTime, string saveUid);

        private void InitializeDataConfigFromFile(string filePath) => this.DataConfiguration = this.serializationService.JsonDeserializeFromFile<TDataConfiguration>(filePath);
    }
}
