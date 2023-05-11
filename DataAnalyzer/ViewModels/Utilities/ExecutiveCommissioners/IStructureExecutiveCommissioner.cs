using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

internal interface IStructureExecutiveCommissioner : INotifyPropertyChanged
{
    IDataStructureSetupViewModel ActiveViewModel { get; }
    string ConfigurationDirectory { get; set; }
    bool DisplayCsvToClassSetup { get; set; }
    bool DisplayGroupingSetup { get; set; }
    bool DisplayNotSupported { get; set; }
    ObservableCollection<string> ExecutionTypes { get; }
    string SelectedExecutionType { get; set; }

    void ApplyConfiguration();
    bool IsValidSetup(out string reason);
    void ClearConfiguration();
    void ClearDisplays();
    void CreateNewDataConfiguration();
    string GetConfigurationDirectory();
    string GetConfigurationName();
    IDataConfiguration GetDataConfiguration();
    TDataConfiguration GetDataConfiguration<TDataConfiguration>() where TDataConfiguration : IDataConfiguration;
    IDataStructureSetupViewModel GetInitializedViewModel();
    void LoadConfiguration(string configName);
    void LoadViewModelFromConfiguration();
    void SaveConfiguration();
    void SetConfigurationName(string name);
    void SetDisplay();
}