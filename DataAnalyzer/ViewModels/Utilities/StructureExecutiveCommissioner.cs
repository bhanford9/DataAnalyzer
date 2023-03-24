using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class StructureExecutiveCommissioner : BasePropertyChanged, IStructureExecutiveCommissioner
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;
        private readonly ExecutiveUtilitiesRepository executiveUtilities = ExecutiveUtilitiesRepository.Instance;
        private EnumUtilities enumUtilities = new();

        private bool displayGroupingSetup = false;
        private bool displayCsvToClassSetup = false;
        private bool displayNotSupported = true;
        private string selectedExportType = string.Empty;
        private string configurationDirectory = string.Empty;
        private readonly IReadOnlyDictionary<string, Action> viewDisplayMap;

        public StructureExecutiveCommissioner()
        {
            this.enumUtilities.LoadNames(typeof(ExportType), this.ExportTypes);

            // TODO --> may want to be converting everything away from ExecutiveType and toward 
            //    just using import/category/flavor/export to access everything
            this.viewDisplayMap = new Dictionary<string, Action>()
            {
                { nameof(DisplayGroupingSetup), () => this.DisplayGroupingSetup = true },
                { nameof(DisplayCsvToClassSetup), () => this.DisplayCsvToClassSetup = true },
                { nameof(DisplayNotSupported), () => this.DisplayNotSupported = true },
            };

            //foreach (var viewModel in this.executiveViewModelMap.Where(x => x.Value != null))
            //{
            //    viewModel.Value.PropertyChanged += GeneralViewModelPropertyChanged;
            //}

            if (!this.configurationModel.HasLoaded)
            {
                this.configurationModel.LoadConfiguration();
            }

            if (this.configurationModel.HasLoaded)
            {
                this.FetchConfiguration();
            }

            this.statsModel.PropertyChanged += this.StatsModelPropertyChanged;
        }

        public ObservableCollection<string> ExportTypes { get; } = new();

        public IDataStructureSetupViewModel ActiveViewModel
            => this.executiveUtilities
                .GetExecutiveOrDefault(this.configurationModel.ImportExportKey)
                .DataStructureSetupViewModel;

        public bool DisplayNotSupported
        {
            get => this.displayNotSupported;
            set => this.NotifyPropertyChanged(ref this.displayNotSupported, value);
        }

        public bool DisplayGroupingSetup
        {
            get => this.displayGroupingSetup;
            set => this.NotifyPropertyChanged(ref this.displayGroupingSetup, value);
        }

        public bool DisplayCsvToClassSetup
        {
            get => this.displayCsvToClassSetup;
            set => this.NotifyPropertyChanged(ref this.displayCsvToClassSetup, value);
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set
            {
                this.mainModel.LoadedDataStructure.ExportType = value;
                this.configurationModel.SelectedExportType = Enum.Parse<ExportType>(value);
                this.NotifyPropertyChanged(ref this.selectedExportType, value);
            }
        }

        public string ConfigurationDirectory
        {
            get => this.configurationDirectory;
            set => this.NotifyPropertyChanged(ref this.configurationDirectory, value);
        }

        public void SetDisplay()
        {
            this.ClearDisplays();
            this.ActiveViewModel.StartListeners();
            this.viewDisplayMap[this.ActiveViewModel.GetDisplayStringName()]();
        }

        public void SetConfigurationName(string name) => this.ActiveViewModel.ConfigurationName = name;

        public string GetConfigurationName() => this.ActiveViewModel.ConfigurationName;

        public string GetConfigurationDirectory() => this.ActiveViewModel.ConfigurationDirectory;

        public bool CanSave(out string reason) => this.ActiveViewModel.CanSave(out reason);

        public void ApplyConfiguration() => this.ActiveViewModel.ApplyConfiguration();

        public void SaveConfiguration() => this.ActiveViewModel.SaveConfiguration();

        public IDataConfiguration GetDataConfiguration() => this.ActiveViewModel.DataConfiguration;

        public TDataConfiguration GetDataConfiguration<TDataConfiguration>()
            where TDataConfiguration : IDataConfiguration
            => (TDataConfiguration)GetDataConfiguration();

        public void CreateNewDataConfiguration() => this.ActiveViewModel.CreateNewDataConfiguration();

        public void LoadConfiguration(string configName)
        {
            IDataStructureSetupViewModel viewModel = this.ActiveViewModel;
            viewModel.LoadConfiguration(configName);

            IDataConfiguration dataConfiguration = this.GetDataConfiguration();

            viewModel.SelectedDataType = dataConfiguration.ImportExportKey;
            viewModel.SelectedExportType = dataConfiguration.ImportExportKey.ExportType.ToString();

            this.configurationModel.ImportExportKey = dataConfiguration.ImportExportKey;
        }

        public IDataStructureSetupViewModel GetInitializedViewModel()
        {
            FetchConfiguration();

            IDataStructureSetupViewModel viewModel = this.ActiveViewModel;
            viewModel.Initialize();
            viewModel.SelectedExportType = this.selectedExportType;

            return viewModel;
        }

        public void ClearConfiguration()
        {
            this.SetConfigurationName(string.Empty);
            this.ActiveViewModel.ClearConfiguration();
        }

        public void ClearDisplays()
        {
            this.DisplayGroupingSetup = false;
            this.DisplayCsvToClassSetup = false;
            this.DisplayNotSupported = false;
            this.executiveUtilities.StructureSetupViewModels.ToList().ForEach(viewModel => viewModel.StopListeners());
        }

        public void LoadViewModelFromConfiguration()
        {
            IDataConfiguration dataConfiguration = this.GetDataConfiguration();

            // This is executed after Export Type is selected. Need to look at input type and export type and select appropriate UI
            this.SetConfigurationName(dataConfiguration.Name);

            // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
            IDataStructureSetupViewModel viewModel = this.ActiveViewModel;
            viewModel.SelectedDataType = dataConfiguration.ImportExportKey;
            viewModel.SelectedExportType = dataConfiguration.ImportExportKey.ExportType.ToString();
            this.DisplayNotSupported = false;
        }

        private void FetchConfiguration()
        {
            this.SelectedExportType = this.configurationModel.SelectedExportType.ToString();
            this.ConfigurationDirectory = this.configurationModel.ExecutiveConfigurationDirectory;
        }

        private void GeneralViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IDataStructureSetupViewModel viewModel = sender as IDataStructureSetupViewModel;

            switch (e.PropertyName)
            {
                case nameof(viewModel.SelectedExportType):
                    this.SelectedExportType = viewModel.SelectedExportType;
                    break;
                case nameof(viewModel.ConfigurationDirectory):
                    this.ConfigurationDirectory = viewModel.ConfigurationDirectory;
                    break;
            }
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(statsModel.Stats):
                    this.ActiveViewModel.Initialize();
                    break;
            }
        }
    }
}
