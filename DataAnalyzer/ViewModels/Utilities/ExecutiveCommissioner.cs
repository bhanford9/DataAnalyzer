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
    internal class ExecutiveCommissioner : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;
        private EnumUtilities EnumUtilities = new();

        private bool displayGroupingSetup = false;
        private bool displayCsvStringSetup = false;
        private bool displayCsvClassSetup = false;
        private bool displayNotSupported = true;
        private string selectedExportType = string.Empty;
        private string configurationDirectory = string.Empty;
        private readonly IReadOnlyDictionary<ExecutiveType, Action> viewDisplayMap;
        private readonly IDictionary<ExecutiveType, IDataStructureSetupViewModel> executiveViewModelMap;

        public ExecutiveCommissioner()
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
                    ExecutiveType.CsvToCSharpStringClass,
                    () =>
                    {
                        this.DisplayCsvStringSetup = true;
                        this.executiveViewModelMap[ExecutiveType.CsvToCSharpStringClass].StartListeners();
                    }
                },
                {
                    ExecutiveType.CsvToCSharpTypedClass,
                    () =>
                    {
                        this.DisplayCsvClassSetup = true;
                        this.executiveViewModelMap[ExecutiveType.CsvToCSharpTypedClass].StartListeners();
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
                { ExecutiveType.CsvToCSharpStringClass, new CsvCSharpStringClassSetupViewModel(this.DataTypes, new CsvCSharpStringClassSetupModel()) },
                { ExecutiveType.CsvToCSharpTypedClass, new CsvCSharpStringClassSetupViewModel(this.DataTypes, new CsvCSharpStringClassSetupModel()) }, // TODO --> replace with typed class
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

        public bool DisplayCsvStringSetup
        {
            get => this.displayCsvStringSetup;
            set => this.NotifyPropertyChanged(ref this.displayCsvStringSetup, value);
        }

        public bool DisplayCsvClassSetup
        {
            get => this.displayCsvClassSetup;
            set => this.NotifyPropertyChanged(ref this.displayCsvClassSetup, value);
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

        public IDataStructureSetupViewModel GetViewModel()
        {
            // This is a bad hack to initialize the view model before returning it.
            // Doing it as a lazy way to support the export type changing at any time.
            this.executiveViewModelMap[this.mainModel.ExecutiveType].SelectedExportType = this.selectedExportType;
            return this.executiveViewModelMap[this.mainModel.ExecutiveType];
        }

        public void ClearConfiguration()
        {
            this.SetConfigurationName(string.Empty);
            this.executiveViewModelMap[this.mainModel.ExecutiveType].ClearConfiguration();
        }

        public void ClearDisplays()
        {
            this.DisplayGroupingSetup = false;
            this.DisplayCsvStringSetup = false;
            this.DisplayCsvClassSetup = false;
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
