using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class StructureExecutiveCommissioner : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private EnumUtilities EnumUtilities = new();

        private bool displayGroupingSetup = false;
        private bool displayCsvToClassSetup = false;
        private bool displayNotSupported = true;
        private string selectedExportType = string.Empty;
        private string configurationDirectory = string.Empty;
        private readonly IReadOnlyDictionary<ExecutiveType, Action> viewDisplayMap;
        private readonly IDictionary<ExecutiveType, IDataStructureSetupViewModel> executiveViewModelMap;

        public StructureExecutiveCommissioner()
        {
            this.EnumUtilities.LoadNames(typeof(StatType), this.DataTypes);
            this.EnumUtilities.LoadNames(typeof(ExportType), this.ExportTypes);

            this.viewDisplayMap = new Dictionary<ExecutiveType, Action>()
            {
                {
                    ExecutiveType.CreateQueryableExcelReport,
                    () =>
                    {
                        this.DisplayGroupingSetup = true;
                        this.executiveViewModelMap[ExecutiveType.CreateQueryableExcelReport].StartListeners();
                    }
                },
                {
                    ExecutiveType.CsvToCSharpClass,
                    () =>
                    {
                        this.DisplayCsvToClassSetup = true;
                        this.executiveViewModelMap[ExecutiveType.CsvToCSharpClass].StartListeners();
                    }
                },
                {
                    ExecutiveType.NotSupported,
                    () =>
                    {
                        this.DisplayNotSupported = true;
                        this.executiveViewModelMap[ExecutiveType.NotSupported].StartListeners(); }
                },
            };

            this.executiveViewModelMap = new Dictionary<ExecutiveType, IDataStructureSetupViewModel>()
            {
                { ExecutiveType.CreateQueryableExcelReport, new GroupingSetupViewModel(this.DataTypes, new GroupingSetupModel()) },
                { ExecutiveType.CsvToCSharpClass, new CsvCSharpStringClassSetupViewModel(this.DataTypes, new CsvCSharpStringClassSetupModel()) },
                { ExecutiveType.NotSupported, new NotSupportedSetupViewModel(this.DataTypes, new NotSupportedSetupModel())},
            };

            foreach (var viewModel in this.executiveViewModelMap.Where(x => x.Value != null))
            {
                viewModel.Value.PropertyChanged += GeneralViewModelPropertyChanged;
            }
        }

        public ObservableCollection<string> DataTypes { get; } = new();
        public ObservableCollection<string> ExportTypes { get; } = new();

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

        public void SetDisplay(ExecutiveType type)
        {
            this.ClearDisplays();
            this.viewDisplayMap[type]();
        }

        public void SetConfigurationName(string name) => this.executiveViewModelMap[this.mainModel.ExecutiveType].ConfigurationName = name;

        public string GetConfigurationName() => this.executiveViewModelMap[this.mainModel.ExecutiveType].ConfigurationName;

        public string GetConfigurationDirectory() => this.executiveViewModelMap[this.mainModel.ExecutiveType].ConfigurationDirectory;

        public bool CanSave(out string reason) => this.executiveViewModelMap[this.mainModel.ExecutiveType].CanSave(out reason);

        public void SaveConfiguration() => this.executiveViewModelMap[this.mainModel.ExecutiveType].SaveConfiguration();
        
        public void LoadConfiguration(string configName) => this.executiveViewModelMap[this.mainModel.ExecutiveType].LoadConfiguration(configName);

        public IDataConfiguration GetDataConfiguration() => this.executiveViewModelMap[this.mainModel.ExecutiveType].DataConfiguration;

        public void CreateNewDataConfiguration() => this.executiveViewModelMap[this.mainModel.ExecutiveType].CreateNewDataConfiguration();

        public IDataStructureSetupViewModel GetInitializedViewModel()
        {
            IDataStructureSetupViewModel viewModel = this.executiveViewModelMap[this.mainModel.ExecutiveType];
            viewModel.Initialize();
            viewModel.SelectedExportType = this.selectedExportType;

            return viewModel;
        }

        public void ClearConfiguration()
        {
            this.SetConfigurationName(string.Empty);
            this.executiveViewModelMap[this.mainModel.ExecutiveType].ClearConfiguration();
        }

        public void ClearDisplays()
        {
            this.DisplayGroupingSetup = false;
            this.DisplayCsvToClassSetup = false;
            this.DisplayNotSupported = false;

            this.executiveViewModelMap.ToList().ForEach(x => x.Value.StopListeners());
        }

        public void LoadViewModelFromConfiguration()
        {
            IDataConfiguration dataConfiguration = this.GetDataConfiguration();

            // This is executed after Export Type is selected. Need to look at input type and export type and select appropriate UI
            this.SetConfigurationName(dataConfiguration.Name);

            // This will update the model which will cause a propogation up to the grouping view models to populate their combo boxes
            IDataStructureSetupViewModel viewModel = this.executiveViewModelMap[this.mainModel.ExecutiveType];
            viewModel.SelectedDataType = dataConfiguration.StatType.ToString();
            viewModel.SelectedExportType = dataConfiguration.ExportType.ToString();
            this.DisplayNotSupported = false;
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
    }
}
