﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using ExcelService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels;

internal class ExcelDashboardViewModel : BasePropertyChanged, IExcelDashboardViewModel
{
    private readonly IExcelSetupModel excelSetupModel;
    private readonly IStructureExecutiveCommissioner executiveCommissioner;
    private readonly IExcelExecutive excelExecutive;

    private readonly BaseCommand startNewConfiguration;
    private readonly BaseCommand saveConfiguration;
    private readonly BaseCommand browseOutputDirectory;
    private readonly BaseCommand executeExcelExecution;

    private string configName = string.Empty;
    private string outputDirectory = string.Empty;

    public ExcelDashboardViewModel(
        IExcelSetupModel excelSetupModel,
        IStructureExecutiveCommissioner executiveCommissioner,
        IExcelExecutive excelExecutive)
    {
        this.excelSetupModel = excelSetupModel;
        this.executiveCommissioner = executiveCommissioner;

        this.startNewConfiguration = new BaseCommand(obj => this.DoStartNewConfiguration());
        this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());
        this.browseOutputDirectory = new BaseCommand(obj => this.DoBrowseOutputDirectory());
        this.executeExcelExecution = new BaseCommand(obj => this.DoExecuteExcelExport());

        this.excelSetupModel.ExcelConfiguration.PropertyChanged += this.ExcelConfigurationPropertyChanged;
        this.excelExecutive = excelExecutive;
    }

    public ObservableCollection<IWorkbookConfigListItemViewModel> SavedWorkbookConfigs { get; } = new();

    public ICommand StartNewConfiguration => this.startNewConfiguration;

    public ICommand SaveConfiguration => this.saveConfiguration;

    public ICommand BrowseOutputDirectory => this.browseOutputDirectory;

    public ICommand ExecuteExcelExecution => this.executeExcelExecution;

    public string ConfigName
    {
        get => this.configName;
        set => this.NotifyPropertyChanged(ref this.configName, value);
    }

    public string OutputDirectory
    {
        get => this.outputDirectory;
        set
        {
            this.NotifyPropertyChanged(ref this.outputDirectory, value);
            this.excelSetupModel.ExcelConfiguration.ApplyWorkbooksOutputPath(this.outputDirectory + "\\" + this.ConfigName);
        }
    }

    private void DoStartNewConfiguration()
    {
        this.excelSetupModel.ExcelConfiguration.WorkbookModels.Clear();
        this.ConfigName = string.Empty;
    }

    private void DoSaveConfiguration()
    {
        // Note, this is not saving the datatypes, but may want to in the future.
        this.excelSetupModel.ApplyTypeParametersToConfig();
        this.excelSetupModel.ExcelConfiguration.WorkbookOutputDirectory = this.OutputDirectory;
        this.excelSetupModel.ExcelConfiguration.SaveWorkbookConfiguration(this.configName);
        this.executiveCommissioner.SaveConfiguration();
    }

    private void DoBrowseOutputDirectory()
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            this.OutputDirectory = folderBrowserDialog.SelectedPath;
        }
    }

    private void DoExecuteExcelExport()
    {
        // This apears to have not converted things correctly
        this.excelSetupModel.ApplyTypeParametersToConfig();
        this.excelExecutive.GenerateWorkbooks(
          this.excelSetupModel.ExcelConfiguration.WorkbookModels
            .Select(x => ExcelWorkbookConverter.WorkbookModelToExcelWorkbook(x))
            .ToList());
    }

    private void ApplyConfigurationDirectory()
    {
        string directoryPath = this.excelSetupModel.ExcelConfiguration.GetCurrentWorkbookConfigDirectoryPath();

        if (Directory.Exists(directoryPath))
        {
            List<string> configFiles = Directory.GetFiles(directoryPath).ToList();
            this.SavedWorkbookConfigs.Clear();

            configFiles.ForEach(configFilePath =>
            {
                string configFile = Path.GetFileName(configFilePath);
                string displayText = configFile;
                while (displayText.Contains("."))
                {
                    displayText = Path.GetFileNameWithoutExtension(displayText);
                }

                this.SavedWorkbookConfigs.Add(new WorkbookConfigListItemViewModel(this.excelSetupModel.ExcelConfiguration)
                { 
                    Value = displayText, 
                    ToolTipText = configFile 
                });
            });
        }
    }

    private void ExcelConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(this.excelSetupModel.ExcelConfiguration.ConfigurationDirectory):
            case nameof(this.excelSetupModel.ExcelConfiguration.WorkbookConfigName):
                this.ApplyConfigurationDirectory();
                this.ConfigName = this.excelSetupModel.ExcelConfiguration.WorkbookConfigName;
                break;
        }
    }
}
