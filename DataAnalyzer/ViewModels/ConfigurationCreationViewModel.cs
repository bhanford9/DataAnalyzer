using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationCreationViewModel : BasePropertyChanged, IConfigurationCreationViewModel
    {
        private readonly IConfigurationModel configModel;

        private IDataStructureSetupViewModel activeViewModel;

        private readonly BaseCommand createConfiguration;
        private readonly BaseCommand cancelChanges;
        private readonly BaseCommand applyWithoutSave;
        private readonly BaseCommand saveConfiguration;

        public ConfigurationCreationViewModel(
            IConfigurationModel configModel,
            IMainModel mainModel,
            IStatsModel statsModel,
            IStructureExecutiveCommissioner executiveCommissioner)
        {
            this.configModel = configModel;
            this.ExecutiveCommissioner = executiveCommissioner;

            // TODO --> get this as resolved default
            this.activeViewModel = new NotSupportedSetupViewModel(configModel, mainModel, statsModel, new(configModel));

            this.InitializeViewModel();
            this.createConfiguration = new BaseCommand(obj => this.DoCreateConfiguration());
            this.cancelChanges = new BaseCommand(obj => this.DoCancelChanges());
            this.applyWithoutSave = new BaseCommand(obj => this.DoApplyConfiguration());
            this.saveConfiguration = new BaseCommand(obj => this.DoSaveConfiguration());

            this.configModel.PropertyChanged += this.ConfigModelPropertyChanged;
        }

        public ICommand CreateConfiguration => this.createConfiguration;
        public ICommand CancelChanges => this.cancelChanges;
        public ICommand ApplyWithoutSave => this.applyWithoutSave;
        public ICommand SaveConfiguration => this.saveConfiguration;

        public ObservableCollection<string> ExportTypes => this.ExecutiveCommissioner.ExportTypes;
        public ObservableCollection<ILoadableRemovableRowViewModel> Configurations { get; } = new();

        public IStructureExecutiveCommissioner ExecutiveCommissioner { get; }

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

                this.Configurations.Add(new ConfigurationFileListItemViewModel(this.ExecutiveCommissioner)
                {
                    Value = displayText,
                    ToolTipText = configFile
                });
            });

            if (!this.Configurations.Any())
            {
                this.DoCreateConfiguration();
            }
        }

        private void InitializeViewModel()
        {
            if (this.configModel.ImportExportKey.IsValid)
            {
                this.ActiveViewModel = this.ExecutiveCommissioner.GetInitializedViewModel();

                if (!this.ActiveViewModel.IsDefault)
                {
                    this.ApplyConfigurationDirectory(this.ExecutiveCommissioner.GetConfigurationDirectory());
                }
            }

            this.ExecutiveCommissioner.SetDisplay();
        }

        private void ConfigModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configModel.ImportExportKey):
                    this.InitializeViewModel();
                    break;
            }
        }
    }
}
