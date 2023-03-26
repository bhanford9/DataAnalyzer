using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
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
        private readonly IConfigurationModel configModel;

        private IDataStructureSetupViewModel activeViewModel = new NotSupportedSetupViewModel(new());

        private readonly BaseCommand createConfiguration;
        private readonly BaseCommand cancelChanges;
        private readonly BaseCommand applyWithoutSave;
        private readonly BaseCommand saveConfiguration;

        public ConfigurationCreationViewModel(
            IConfigurationModel configModel,
            IStructureExecutiveCommissioner executiveCommissioner)
        {
            this.configModel = configModel;
            this.ExecutiveCommissioner = executiveCommissioner;

            this.InitializeViewModel();
            this.createConfiguration = new BaseCommand(obj => this.DoCreateConfiguration());
            this.cancelChanges = new BaseCommand(obj => this.DoCancelChanges());
            this.applyWithoutSave = new BaseCommand(obj => this.DoApplyConfiguration());
            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());

            this.configModel.PropertyChanged += this.ConfigModelPropertyChanged;

            this.ExecutiveCommissioner.PropertyChanged += this.ExecutiveCommissionerPropertyChanged;
        }

        public ICommand CreateConfiguration => this.createConfiguration;
        public ICommand CancelChanges => this.cancelChanges;
        public ICommand ApplyWithoutSave => this.applyWithoutSave;
        public ICommand SaveConfiguration => this.saveConfiguration;

        public ObservableCollection<string> ExportTypes => this.ExecutiveCommissioner.ExportTypes;
        public ObservableCollection<LoadableRemovableRowViewModel> Configurations { get; } = new();

        public IStructureExecutiveCommissioner ExecutiveCommissioner { get; }

        //public ExecutiveType ExecutiveType
        //{
        //    get => this.executiveType;
        //    set => this.NotifyPropertyChanged(ref this.executiveType, value);
        //}

        public IDataStructureSetupViewModel ActiveViewModel
        {
            get => this.activeViewModel;
            set => this.NotifyPropertyChanged(ref this.activeViewModel, value);
        }

        private void DoCreateConfiguration()
        {
            this.ExecutiveCommissioner.DisplayNotSupported = false;
            this.ClearConfigurationData();
            this.ExecutiveCommissioner.CreateNewDataConfiguration();
        }

        private void DoCancelChanges()
        {
            this.ExecutiveCommissioner.DisplayNotSupported = true;
            this.ClearConfigurationData();
        }

        private void ClearConfigurationData() => this.ExecutiveCommissioner.ClearConfiguration();

        private bool DoApplyConfiguration()
        {
            if (string.IsNullOrEmpty(this.ExecutiveCommissioner.GetConfigurationName()))
            {
                // TODO --> Display that there is a problem
                return false;
            }

            if (!this.ExecutiveCommissioner.IsValidSetup(out string reason))
            {
                // TODO --> Display that there is a problem
                return false;
            }

            this.ExecutiveCommissioner.ApplyConfiguration();
            return true;
        }

        private void DoSaveConfiguration()
        {
            if (this.DoApplyConfiguration())
            {
                this.ExecutiveCommissioner.SaveConfiguration();
            }
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

            if (!this.Configurations.Any())
            {
                this.DoCreateConfiguration();
            }
        }

        private void InitializeViewModel()
        {
            //this.ExecutiveType = this.mainModel.ExecutiveType;

            //if (this.ExecutiveType != ExecutiveType.NotSupported)
            if (this.configModel.ImportExportKey.IsValid)
            {
                this.ActiveViewModel = this.ExecutiveCommissioner.GetInitializedViewModel();
                this.ApplyConfigurationDirectory(this.ExecutiveCommissioner.GetConfigurationDirectory());
            }

            this.ExecutiveCommissioner.SetDisplay();
        }

        private void ConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configModel.ImportExportKey):
                    // TODO --> might need to update page
                    break;
            }
        }

        private void ExecutiveCommissionerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.ExecutiveCommissioner.SelectedExportType):
                    this.InitializeViewModel();
                    break;
            }
        }
    }
}
