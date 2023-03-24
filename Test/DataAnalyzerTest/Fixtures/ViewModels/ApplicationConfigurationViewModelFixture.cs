using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;

namespace DataAnalyzerTest.Fixtures.ViewModels
{
    public class ApplicationConfigurationViewModelFixture : BaseFixture
    {
        public ApplicationConfigurationViewModelFixture()
        {
            // one time setup
        }

        internal string ExpectedDirectory { get; } = "directory";

        internal string ExpectedName { get; } = "name";

        internal IConfigurationModel ConfigurationModel { get; set; }

        internal ApplicationConfigurationViewModel ViewModel { get; set; }
    }
}
