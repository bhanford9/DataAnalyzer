using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Services;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal interface IDataStructureSetupViewModel : INotifyPropertyChanged
    {
        string ConfigurationName { get; set; }
        ImportExportKey SelectedDataType { get; set; }
        string ConfigurationDirectory { get; set; }
        string SelectedExportType { get; set; }
        IDataConfiguration DataConfiguration { get; }

        bool CanSave(out string reason);
        void ClearConfiguration();
        void CreateNewDataConfiguration();
        void Initialize();
        void LoadConfiguration(string configName);
        void LoadViewModelFromConfiguration();
        void ApplyConfiguration();
        void SaveConfiguration();
        void StartListeners();
        void StopListeners();
        string GetDisplayStringName();
    }
}