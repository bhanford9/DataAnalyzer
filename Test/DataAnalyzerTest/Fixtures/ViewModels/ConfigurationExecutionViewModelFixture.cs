using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerTest.Fixtures.ViewModels
{
    public class ConfigurationExecutionViewModelFixture : BaseFixture
    {
        public ConfigurationExecutionViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IExecutionExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal Mock<IImportExportKey> MockKey { get; set; }

        internal string ConfigKeyPropName => nameof(this.MockConfigurationModel.Object.ImportExportKey);

        internal PropertyChangedEventArgs ConfigKeyChangeArgs => this.GetNamedEventArgs(this.ConfigKeyPropName);

        internal ConfigurationExecutionViewModel ViewModel { get; set; }
    }
}
