using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.ExecutiveUtilities;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal class StructureExecutiveCommissioner : BasePropertyChanged, IStructureExecutiveCommissioner
    {
        private readonly IConfigurationModel configurationModel;
        private readonly IMainModel mainModel;
        private readonly IStatsModel statsModel;
        private readonly IExecutiveUtilitiesRepository executiveUtilities = ExecutiveUtilitiesRepository.Instance;
        private readonly EnumUtilities enumUtilities = new();

        private bool displayGroupingSetup = false;
        private bool displayCsvToClassSetup = false;
        private bool displayNotSupported = true;
        private string selectedExportType = string.Empty;
        private string configurationDirectory = string.Empty;
        private readonly IReadOnlyDictionary<string, Action> viewDisplayMap;

        public StructureExecutiveCommissioner(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            IStatsModel statsModel)
        {
            this.configurationModel = configurationModel;
            this.mainModel = mainModel;
            this.statsModel = statsModel;
            enumUtilities.LoadNames(typeof(ExportType), ExportTypes);

            viewDisplayMap = new Dictionary<string, Action>()
            {
                { nameof(DisplayGroupingSetup), () => DisplayGroupingSetup = true },
                { nameof(DisplayCsvToClassSetup), () => DisplayCsvToClassSetup = true },
                { nameof(DisplayNotSupported), () => DisplayNotSupported = true },
            };

            if (configurationModel.HasLoaded)
            {
                FetchConfiguration();
            }

            statsModel.PropertyChanged += StatsModelPropertyChanged;
        }

        public ObservableCollection<string> ExportTypes { get; } = new();

        public IDataStructureSetupViewModel ActiveViewModel
            => executiveUtilities
                .GetExecutiveOrDefault(configurationModel.ImportExportKey)
                .DataStructureSetupViewModel;

        public bool DisplayNotSupported
        {
            get => displayNotSupported;
            set => NotifyPropertyChanged(ref displayNotSupported, value);
        }

        public bool DisplayGroupingSetup
        {
            get => displayGroupingSetup;
            set => NotifyPropertyChanged(ref displayGroupingSetup, value);
        }

        public bool DisplayCsvToClassSetup
        {
            get => displayCsvToClassSetup;
            set => NotifyPropertyChanged(ref displayCsvToClassSetup, value);
        }

        public string SelectedExportType
        {
            get => selectedExportType;
            set
            {
                mainModel.LoadedDataStructure.ExportType = value;
                configurationModel.SelectedExportType = Enum.Parse<ExportType>(value);
                NotifyPropertyChanged(ref selectedExportType, value);
            }
        }

        public string ConfigurationDirectory
        {
            get => configurationDirectory;
            set => NotifyPropertyChanged(ref configurationDirectory, value);
        }

        public void SetDisplay()
        {
            ClearDisplays();
            ActiveViewModel.StartListeners();
            viewDisplayMap[ActiveViewModel.GetDisplayStringName()]();
        }

        public void SetConfigurationName(string name) => ActiveViewModel.ConfigurationName = name;

        public string GetConfigurationName() => ActiveViewModel.ConfigurationName;

        public string GetConfigurationDirectory() => ActiveViewModel.ConfigurationDirectory;

        public bool IsValidSetup(out string reason) => ActiveViewModel.IsValidSetup(out reason);

        public void ApplyConfiguration() => ActiveViewModel.ApplyConfiguration();

        public void SaveConfiguration() => ActiveViewModel.SaveConfiguration();

        public IDataConfiguration GetDataConfiguration() => ActiveViewModel.DataConfiguration;

        public TDataConfiguration GetDataConfiguration<TDataConfiguration>()
            where TDataConfiguration : IDataConfiguration
            => (TDataConfiguration)GetDataConfiguration();

        public void CreateNewDataConfiguration() => ActiveViewModel.CreateNewDataConfiguration();

        public void LoadConfiguration(string configName)
        {
            IDataStructureSetupViewModel viewModel = ActiveViewModel;
            viewModel.LoadConfiguration(configName);

            IDataConfiguration dataConfiguration = GetDataConfiguration();

            viewModel.SelectedDataType = dataConfiguration.ImportExportKey;
            viewModel.SelectedExportType = dataConfiguration.ImportExportKey.ExportType.ToString();

            configurationModel.ImportExportKey = dataConfiguration.ImportExportKey;
        }

        public IDataStructureSetupViewModel GetInitializedViewModel()
        {
            FetchConfiguration();

            IDataStructureSetupViewModel viewModel = ActiveViewModel;
            viewModel.Initialize();
            viewModel.SelectedExportType = selectedExportType;

            return viewModel;
        }

        public void ClearConfiguration()
        {
            SetConfigurationName(string.Empty);
            ActiveViewModel.ClearConfiguration();
        }

        public void ClearDisplays()
        {
            DisplayGroupingSetup = false;
            DisplayCsvToClassSetup = false;
            DisplayNotSupported = false;
            executiveUtilities.StructureSetupViewModels.ToList().ForEach(viewModel => viewModel.StopListeners());
        }

        public void LoadViewModelFromConfiguration()
        {
            IDataConfiguration dataConfiguration = GetDataConfiguration();

            // This is executed after Export Type is selected. Need to look at input type and export type and select appropriate UI
            SetConfigurationName(dataConfiguration.Name);

            // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
            IDataStructureSetupViewModel viewModel = ActiveViewModel;
            viewModel.SelectedDataType = dataConfiguration.ImportExportKey;
            viewModel.SelectedExportType = dataConfiguration.ImportExportKey.ExportType.ToString();
            DisplayNotSupported = false;
        }

        private void FetchConfiguration()
        {
            SelectedExportType = configurationModel.SelectedExportType.ToString();
            ConfigurationDirectory = configurationModel.ExecutiveConfigurationDirectory;
        }

        private void GeneralViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IDataStructureSetupViewModel viewModel = sender as IDataStructureSetupViewModel;

            switch (e.PropertyName)
            {
                case nameof(viewModel.SelectedExportType):
                    SelectedExportType = viewModel.SelectedExportType;
                    break;
                case nameof(viewModel.ConfigurationDirectory):
                    ConfigurationDirectory = viewModel.ConfigurationDirectory;
                    break;
            }
        }

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(statsModel.Stats):
                    ActiveViewModel.Initialize();
                    break;
            }
        }
    }
}
