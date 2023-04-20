using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels
{
    public class ConfigurationCreationViewModelFixture : BaseFixture
    {
        public ConfigurationCreationViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IMainModel> MockMainModel { get; set; }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<IStructureExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal Mock<IImportExportKey> MockKey { get; set; }

        internal Mock<INotSupportedSetupViewModel> MockDefaultView { get; set; }

        internal Mock<INotSupportedSetupModel> MockNotSupportedSetupModel { get; set; }

        internal string ConfigKeyPropName => nameof(this.MockConfigurationModel.Object.ImportExportKey);

        internal PropertyChangedEventArgs ConfigKeyChangeArgs => this.GetNamedEventArgs(this.ConfigKeyPropName);

        internal ConfigurationCreationViewModel ViewModel { get; set; }
    }
}
