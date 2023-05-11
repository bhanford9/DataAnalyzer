﻿using DataAnalyzer.ApplicationConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;
using System;
using System.IO;

namespace DataAnalyzer.Models.DataStructureSetupModels;

internal abstract class DataStructureSetupModel<TDataConfiguration> : BasePropertyChanged, IDataStructureSetupModel<TDataConfiguration>
    where TDataConfiguration : IDataConfiguration, new()
{
    protected readonly ISerializationService serializationService;
    protected readonly IConfigurationModel configurationModel;

    protected DataStructureSetupModel(
        ISerializationService serializationService,
        IConfigurationModel configurationModel)
    {
        this.serializationService = serializationService;
        this.configurationModel = configurationModel;
    }

    public TDataConfiguration DataConfiguration { get; protected set; } = new TDataConfiguration();

    public void LoadConfiguration(string configName)
    {
        string filePath = Path.Combine(
            this.configurationModel.ExecutiveConfigurationDirectory,
            configName + FileProperties.CONFIGN_FILE_EXTENSION);
        this.configurationModel.ExecutiveConfigurationName = configName;
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

        this.DataConfiguration.ImportExecutionKey = this.configurationModel.ImportExecutionKey;            
        this.DataConfiguration.ImportExecutionKey.Update(this.configurationModel.SelectedExecutionType);

        // TODO --> the configuration model should just supply this path
        string fullFilePath = this.configurationModel.ExecutiveConfigurationDirectory + "\\" + 
            this.configurationModel.ExecutiveConfigurationName + FileProperties.CONFIGN_FILE_EXTENSION;
        this.serializationService.JsonSerializeToFile(this.DataConfiguration, fullFilePath);
    }

    public void CreateNewDataConfiguration() => this.DataConfiguration = new TDataConfiguration();

    protected abstract void PrepareConfigurationForSaving(DateTime saveTime, string saveUid);

    private void InitializeDataConfigFromFile(string filePath) => this.DataConfiguration = this.serializationService.JsonDeserializeFromFile<TDataConfiguration>(filePath);
}
