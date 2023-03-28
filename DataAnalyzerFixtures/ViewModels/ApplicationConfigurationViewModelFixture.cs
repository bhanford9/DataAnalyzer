using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels
{
    public class ApplicationConfigurationViewModelFixture : BaseFixture
    {
        public ApplicationConfigurationViewModelFixture()
        {
            // one time setup
        }

        internal string ExpectedDirectory { get; } = "directory";

        internal string ExpectedName { get; } = "name";

        internal string ConfigDirectoryPropName => nameof(this.MockConfigurationModel.Object.ConfigurationDirectory);

        internal string ConfigNamePropName => nameof(this.MockConfigurationModel.Object.ConfigurationName);

        internal PropertyChangedEventArgs ConfigDirectoryChangeArgs => this.GetNamedEventArgs(this.ConfigDirectoryPropName);

        internal PropertyChangedEventArgs ConfigNameChangeArgs => this.GetNamedEventArgs(this.ConfigNamePropName);

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal ApplicationConfigurationViewModel ViewModel { get; set; }
    }
}
