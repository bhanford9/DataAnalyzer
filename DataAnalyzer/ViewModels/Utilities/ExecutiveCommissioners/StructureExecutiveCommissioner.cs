using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners
{
    internal class StructureExecutiveCommissioner : BasePropertyChanged, IStructureExecutiveCommissioner
    {
        private readonly IConfigurationModel configurationModel;
        private readonly IMainModel mainModel;
        private readonly IStatsModel statsModel;
        //private readonly IExecutiveUtilitiesRepository executiveUtilities;
        private readonly EnumUtilities enumUtilities = new();

        private bool displayGroupingSetup = false;
        private bool displayCsvToClassSetup = false;
        private bool displayNotSupported = true;
        private string selectedExecutionType = string.Empty;
        private string configurationDirectory = string.Empty;
        private readonly IReadOnlyDictionary<string, Action> viewDisplayMap;

        // TODO --> doing this to bypass some DI circular dependency. need to figure out better solution
        private readonly Lazy<IDataStructureSetupViewModelRepository> setupViewModelRepository
            = new (() => Resolver.Resolve<IDataStructureSetupViewModelRepository>());

        public StructureExecutiveCommissioner(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            IStatsModel statsModel)
            //IExecutiveUtilitiesRepository executiveUtilities,
            //IDataStructureSetupViewModelRepository setupViewModelRepository)
        {
            this.configurationModel = configurationModel;
            this.mainModel = mainModel;
            this.statsModel = statsModel;
            //this.executiveUtilities = executiveUtilities;
            //this.setupViewModelRepository = setupViewModelRepository;
            enumUtilities.LoadNames(typeof(ExecutionType), ExecutionTypes);

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

        public ObservableCollection<string> ExecutionTypes { get; } = new();

        // TODO --> must track this locally so the executive utilities doesn't need to
        //   circular dependency in dependency injection
        public IDataStructureSetupViewModel ActiveViewModel
            => this.setupViewModelRepository.Value.GetDataOr(
                configurationModel.ImportExecutionKey,
                _ => Resolver.Resolve<INotSupportedSetupViewModel>());

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

        public string SelectedExecutionType
        {
            get => selectedExecutionType;
            set
            {
                mainModel.LoadedDataStructure.ExecutionType = value;
                configurationModel.SelectedExecutionType = Enum.Parse<ExecutionType>(value);
                NotifyPropertyChanged(ref selectedExecutionType, value);
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

            viewModel.SelectedDataType = dataConfiguration.ImportExecutionKey;
            viewModel.SelectedExecutionType = dataConfiguration.ImportExecutionKey.ExecutionType.ToString();

            configurationModel.ImportExecutionKey = dataConfiguration.ImportExecutionKey;
        }

        public IDataStructureSetupViewModel GetInitializedViewModel()
        {
            FetchConfiguration();

            IDataStructureSetupViewModel viewModel = ActiveViewModel;
            viewModel.Initialize();
            viewModel.SelectedExecutionType = selectedExecutionType;

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
            // TODO --> removed due to circular dependency injection
            //executiveUtilities.StructureSetupViewModels.ToList().ForEach(viewModel => viewModel.StopListeners());
        }

        public void LoadViewModelFromConfiguration()
        {
            IDataConfiguration dataConfiguration = GetDataConfiguration();

            // This is executed after Execution Type is selected. Need to look at input type and execution type and select appropriate UI
            SetConfigurationName(dataConfiguration.Name);

            // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
            IDataStructureSetupViewModel viewModel = ActiveViewModel;
            viewModel.SelectedDataType = dataConfiguration.ImportExecutionKey;
            viewModel.SelectedExecutionType = dataConfiguration.ImportExecutionKey.ExecutionType.ToString();
            DisplayNotSupported = false;
        }

        private void FetchConfiguration()
        {
            SelectedExecutionType = configurationModel.SelectedExecutionType.ToString();
            ConfigurationDirectory = configurationModel.ExecutiveConfigurationDirectory;
        }

        private void GeneralViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IDataStructureSetupViewModel viewModel = sender as IDataStructureSetupViewModel;

            switch (e.PropertyName)
            {
                case nameof(viewModel.SelectedExecutionType):
                    SelectedExecutionType = viewModel.SelectedExecutionType;
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
