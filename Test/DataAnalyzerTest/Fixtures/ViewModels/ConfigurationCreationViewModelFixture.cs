using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities;
using Moq;

namespace DataAnalyzerTest.Fixtures.ViewModels
{
    public class ConfigurationCreationViewModelFixture : BaseFixture
    {
        public ConfigurationCreationViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IStructureExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal ConfigurationCreationViewModel ViewModel { get; set; }
    }
}
