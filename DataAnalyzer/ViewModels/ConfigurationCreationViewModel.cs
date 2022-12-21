using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationCreationViewModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        private bool isCreating = false;
        private string configurationDirectory = string.Empty;
        private string configurationName = string.Empty;
        private string selectedDataType = string.Empty;
        private string selectedExportType = string.Empty;
        private int groupingLayersCount = 0;
        private EnumUtilities EnumUtilities = new();

        private readonly BaseCommand browseDirectory;
        private readonly BaseCommand createConfiguration;
        private readonly BaseCommand cancelChanges;
        private readonly BaseCommand saveConfiguration;

        public ConfigurationCreationViewModel()
        {
            this.browseDirectory = new BaseCommand(obj => this.DoBrowseDirectory());
            this.createConfiguration = new BaseCommand(obj => this.DoCreateConfiguration());
            this.cancelChanges = new BaseCommand(obj => this.DoCancelChanges());
            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());

            this.ConfigurationDirectory = Properties.Settings.Default.LastUsedConfigurationDirectory;
            this.ApplyConfigurationDirectory(this.ConfigurationDirectory);

            this.EnumUtilities.LoadNames(typeof(StatType), this.DataTypes);
            this.EnumUtilities.LoadNames(typeof(ExportType), this.ExportTypes);

            this.configurationModel.PropertyChanged += this.ConfigurationCreationModelPropertyChanged;
        }

        public ICommand BrowseDirectory => this.browseDirectory;
        public ICommand CreateConfiguration => this.createConfiguration;
        public ICommand CancelChanges => this.cancelChanges;
        public ICommand SaveConfiguration => this.saveConfiguration;

        public ObservableCollection<string> DataTypes { get; } = new();
        public ObservableCollection<string> ExportTypes { get; } = new();

        public ObservableCollection<ConfigurationGroupingViewModel> ConfigurationGroupings { get; } = new();

        public ObservableCollection<LoadableRemovableRowViewModel> Configurations { get; } = new();

        public bool IsCreating
        {
            get => this.isCreating;
            set => this.NotifyPropertyChanged(ref this.isCreating, value);
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationDirectory, value);
                this.configurationModel.ConfigurationDirectory = value;
                this.mainModel.LoadedDataStructure.DirectoryPath = value;
            }
        }

        public string ConfigurationName
        {
            get => this.configurationName;
            set
            {
                this.NotifyPropertyChanged(ref this.configurationName, value);
                this.configurationModel.ConfigurationName = value;
                this.mainModel.LoadedDataStructure.StructureName = value;
            }
        }

        public string SelectedDataType
        {
            get => this.selectedDataType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedDataType, value);
                this.configurationModel.SelectedDataType = Enum.Parse<StatType>(value);
                this.mainModel.LoadedDataStructure.DataType = value;
            }
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set
            {
                this.NotifyPropertyChanged(ref this.selectedExportType, value);
                this.configurationModel.SelectedExportType = Enum.Parse<ExportType>(value);
                this.mainModel.LoadedDataStructure.ExportType = value;
            }
        }

        public int GroupingLayersCount
        {
            get => this.groupingLayersCount;
            set
            {
                this.NotifyPropertyChanged(ref this.groupingLayersCount, value);
                this.mainModel.LoadedDataStructure.GroupingsCount = value;

                while (this.GroupingLayersCount > this.ConfigurationGroupings.Count)
                {
                    this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(this.ConfigurationGroupings.Count()));
                }

                while (this.GroupingLayersCount >= 0 && this.GroupingLayersCount < this.ConfigurationGroupings.Count)
                {
                    this.ConfigurationGroupings.RemoveAt(this.ConfigurationGroupings.Count - 1);
                }
            }
        }

        private void DoBrowseDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ApplyConfigurationDirectory(folderBrowserDialog.SelectedPath);
            }
        }

        private void DoCreateConfiguration()
        {
            this.IsCreating = true;
            this.ClearConfigurationData();
            this.configurationModel.CreateNewDataConfiguration();
        }

        private void DoCancelChanges()
        {
            this.IsCreating = false;
            this.ClearConfigurationData();
        }

        private void ClearConfigurationData()
        {
            this.ConfigurationName = string.Empty;
            this.SelectedDataType = StatType.NotApplicable.ToString();
            this.GroupingLayersCount = 0;
            this.ConfigurationGroupings.Clear();
        }

        private void DoSaveConfiguration()
        {
            if (string.IsNullOrEmpty(this.configurationName))
            {
                // TODO --> Display that there is a problem
                return;
            }

            if (string.IsNullOrEmpty(this.selectedDataType))
            {
                // TODO --> Display that there is a problem
                return;
            }

            this.configurationModel.ClearGroupingConfigurations();

            int level = 0;
            this.ConfigurationGroupings.ToList().ForEach(configGroupingViewModel =>
            {
                this.configurationModel.AddGroupingConfiguration(new GroupingConfiguration
                {
                    GroupLevel = level++,
                    GroupName = configGroupingViewModel.Name,
                    SelectedParameter = configGroupingViewModel.SelectedParameter
                });
            });

            this.configurationModel.SaveConfiguration();
        }

        private void ApplyConfigurationDirectory(string file)
        {
            if (Directory.Exists(file))
            {
                this.ConfigurationDirectory = file;
                List<string> configFiles = Directory.GetFiles(file).ToList();
                this.Configurations.Clear();

                configFiles.ForEach(configFilePath =>
                {
                    string configFile = Path.GetFileName(configFilePath);
                    string displayText = configFile;
                    while (displayText.Contains("."))
                    {
                        displayText = Path.GetFileNameWithoutExtension(displayText);
                    }

                    this.Configurations.Add(new ConfigurationFileListItemViewModel { Value = displayText, ToolTipText = configFile });
                });
            }
        }

        private void LoadViewModelFromConfiguration()
        {
            this.ConfigurationName = this.configurationModel.DataConfiguration.Name;
            this.GroupingLayersCount = this.configurationModel.DataConfiguration.GroupingConfiguration.Count;
            this.ConfigurationGroupings.Clear();

            int level = 0;
            foreach (GroupingConfiguration groupingConfig in this.configurationModel.DataConfiguration.GroupingConfiguration)
            {
                this.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(level++)
                {
                    Name = groupingConfig.GroupName,
                    SelectedParameter = groupingConfig.SelectedParameter,
                });
            }

            // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
            this.SelectedDataType = this.configurationModel.DataConfiguration.StatType.ToString();
            this.SelectedExportType = this.configurationModel.DataConfiguration.ExportType.ToString();
            this.IsCreating = true;
        }

        private void ConfigurationCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.SelectedDataType):
                    this.SelectedDataType = Enum.GetName(typeof(StatType), this.configurationModel.SelectedDataType);
                    break;
                case nameof(this.configurationModel.SelectedExportType):
                    this.SelectedExportType = Enum.GetName(typeof(ExportType), this.configurationModel.SelectedExportType);
                    break;
                case nameof(this.configurationModel.DataConfiguration):
                    this.LoadViewModelFromConfiguration();
                    break;
                case nameof(this.configurationModel.RemoveLevel):
                    this.ConfigurationGroupings.RemoveAt(this.configurationModel.RemoveLevel);

                    this.groupingLayersCount--;
                    this.NotifyPropertyChanged(nameof(this.GroupingLayersCount));
                    break;
                default:
                    break;
            }
        }
    }
}
