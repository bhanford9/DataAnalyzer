using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationCreationViewModel : BasePropertyChanged
    {
        //private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly ExecutiveCommissioner executiveCommissioner = BaseSingleton<ExecutiveCommissioner>.Instance;

        private ExecutiveType executiveType = ExecutiveType.NotSupported;
        private IDataStructureSetupViewModel activeViewModel;

        private readonly BaseCommand createConfiguration;
        private readonly BaseCommand cancelChanges;
        private readonly BaseCommand saveConfiguration;

        public ConfigurationCreationViewModel()
        {
            this.createConfiguration = new BaseCommand(obj => this.DoCreateConfiguration());
            this.cancelChanges = new BaseCommand(obj => this.DoCancelChanges());
            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());

            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
            //this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
            this.executiveCommissioner.PropertyChanged += this.ExecutiveCommissionerPropertyChanged;
        }

        public ICommand CreateConfiguration => this.createConfiguration;
        public ICommand CancelChanges => this.cancelChanges;
        public ICommand SaveConfiguration => this.saveConfiguration;

        public ObservableCollection<string> DataTypes => this.executiveCommissioner.DataTypes;
        public ObservableCollection<string> ExportTypes => this.executiveCommissioner.ExportTypes;
        public ObservableCollection<LoadableRemovableRowViewModel> Configurations { get; } = new();

        public ExecutiveType ExecutiveType
        {
            get => this.executiveType;
            set => this.NotifyPropertyChanged(ref this.executiveType, value);
        }

        public IDataStructureSetupViewModel ActiveViewModel
        {
            get => this.activeViewModel;
            set => this.NotifyPropertyChanged(ref this.activeViewModel, value);
        }

        private void DoCreateConfiguration()
        {
            this.executiveCommissioner.DisplayNotSupported = false;
            this.ClearConfigurationData();
            this.executiveCommissioner.CreateNewDataConfiguration();
        }

        private void DoCancelChanges()
        {
            this.executiveCommissioner.DisplayNotSupported = true;
            this.ClearConfigurationData();
        }

        private void ClearConfigurationData()
        {
            this.executiveCommissioner.ClearConfiguration();
        }

        private void DoSaveConfiguration()
        {
            if (string.IsNullOrEmpty(this.executiveCommissioner.GetConfigurationName()))
            {
                // TODO --> Display that there is a problem
                return;
            }

            if (!this.executiveCommissioner.CanSave(out string reason))
            {
                // TODO --> Display that there is a problem
                return;
            }

            this.executiveCommissioner.SaveConfiguration();
        }

        private void ApplyConfigurationDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);

            List<string> configFiles = Directory.GetFiles(directoryPath).ToList();
            this.Configurations.Clear();

            configFiles.ForEach(configFilePath =>
            {
                string configFile = Path.GetFileName(configFilePath);
                string displayText = configFile;
                while (displayText.Contains('.'))
                {
                    displayText = Path.GetFileNameWithoutExtension(displayText);
                }

                this.Configurations.Add(new ConfigurationFileListItemViewModel { Value = displayText, ToolTipText = configFile });
            });
        }

        private void MainModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ExecutiveType):
                    this.ExecutiveType = this.mainModel.ExecutiveType;
                    break;
            }
        }

        private void ExecutiveCommissionerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.executiveCommissioner.SelectedExportType):
                    if (this.ExecutiveType != ExecutiveType.NotSupported)
                    {
                        this.ActiveViewModel = this.executiveCommissioner.GetViewModel();
                        this.ApplyConfigurationDirectory(this.executiveCommissioner.GetConfigurationDirectory());
                    }

                    this.executiveCommissioner.SetDisplay(this.ExecutiveType);
                    break;
            }
        }

        //private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    switch (e.PropertyName)
        //    {
        //        case nameof(this.configurationModel.ActiveModel.DataConfiguration):
        //            this.executiveCommissioner.LoadViewModelFromConfiguration(this.ExecutiveType);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
