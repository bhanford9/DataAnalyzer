using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzerTest.Fixtures.ViewModels;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ApplicationConfigurationViewModelTests : IClassFixture<ApplicationConfigurationViewModelFixture>
    {
        private readonly ApplicationConfigurationViewModelFixture shared;

        public ApplicationConfigurationViewModelTests(ApplicationConfigurationViewModelFixture sharedData)
        {
            // fact setup
            this.shared = sharedData;
            this.shared.ConfigurationModel = new ConfigurationModel();
            this.shared.ConfigurationModel.ConfigurationDirectory = string.Empty;
            this.shared.ConfigurationModel.ConfigurationName = string.Empty;
            this.shared.ViewModel = new ApplicationConfigurationViewModel(this.shared.ConfigurationModel);
        }        

        [Fact]
        public void ShouldHaveConfigurationModelInformationOnCreation()
        {
            this.shared.ConfigurationModel = new ConfigurationModel();
            this.shared.ConfigurationModel.ConfigurationDirectory = this.shared.ExpectedDirectory;
            this.shared.ConfigurationModel.ConfigurationName = this.shared.ExpectedName;

            this.shared.ViewModel = new ApplicationConfigurationViewModel(this.shared.ConfigurationModel);

            Assert.Equal(this.shared.ExpectedDirectory, this.shared.ViewModel.SelectedDirectory);
            Assert.Equal(this.shared.ExpectedName, this.shared.ViewModel.ConfigName);
        }

        [Fact]
        public void ShouldReceiveConfigurationModelChanges()
        {
            this.shared.ConfigurationModel.ConfigurationDirectory = this.shared.ExpectedDirectory;
            this.shared.ConfigurationModel.ConfigurationName = this.shared.ExpectedName;

            Assert.Equal(this.shared.ExpectedDirectory, this.shared.ViewModel.SelectedDirectory);
            Assert.Equal(this.shared.ExpectedName, this.shared.ViewModel.ConfigName);
        }

        [Fact]
        public void ShouldApplyConfigurationModelChanges()
        {
            // 3. set view model directory & name, invoke apply, verify config model
            this.shared.ViewModel.SelectedDirectory = this.shared.ExpectedDirectory;
            this.shared.ViewModel.ConfigName = this.shared.ExpectedName;

            Assert.NotEqual(this.shared.ExpectedDirectory, this.shared.ConfigurationModel.ConfigurationDirectory);
            Assert.NotEqual(this.shared.ExpectedName, this.shared.ConfigurationModel.ConfigurationName);

            this.shared.ViewModel.Apply.Execute(null);

            Assert.Equal(this.shared.ExpectedDirectory, this.shared.ConfigurationModel.ConfigurationDirectory);
            Assert.Equal(this.shared.ExpectedName, this.shared.ConfigurationModel.ConfigurationName);
        }
    }
}
