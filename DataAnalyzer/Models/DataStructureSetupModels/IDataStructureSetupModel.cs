using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System.ComponentModel;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal interface IDataStructureSetupModel<TDataConfiguration> : INotifyPropertyChanged
        where TDataConfiguration : IDataConfiguration, new()
    {
        TDataConfiguration DataConfiguration { get; }

        void CreateNewDataConfiguration();
        void LoadConfiguration(string configName);
        void SaveConfiguration();
    }
}