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
            this.shared = sharedData;
            this.shared.MockConfigurationModel = new();
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(string.Empty);
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(string.Empty);
            this.shared.ViewModel = new ApplicationConfigurationViewModel(this.shared.MockConfigurationModel.Object);
        }

        [Fact]
        public void ShouldHaveConfigurationModelInformationOnCreation()
        {
            this.shared.MockConfigurationModel = new();
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(this.shared.ExpectedDirectory);
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(this.shared.ExpectedName);

            this.shared.ViewModel = new ApplicationConfigurationViewModel(this.shared.MockConfigurationModel.Object);

            Assert.Equal(this.shared.ExpectedDirectory, this.shared.ViewModel.SelectedDirectory);
            Assert.Equal(this.shared.ExpectedName, this.shared.ViewModel.ConfigName);
        }

        [Fact]
        public void ShouldApplyConfigurationModelChanges()
        {
            this.shared.ViewModel.SelectedDirectory = this.shared.ExpectedDirectory;
            this.shared.ViewModel.ConfigName = this.shared.ExpectedName;

            Assert.NotEqual(this.shared.ExpectedDirectory, this.shared.MockConfigurationModel.Object.ConfigurationDirectory);
            Assert.NotEqual(this.shared.ExpectedName, this.shared.MockConfigurationModel.Object.ConfigurationName);

            this.shared.ViewModel.Apply.Execute(null);

            this.shared.MockConfigurationModel.VerifySet(x => x.ConfigurationDirectory = this.shared.ExpectedDirectory);
            this.shared.MockConfigurationModel.VerifySet(x => x.ConfigurationName = this.shared.ExpectedName);
        }

        [Fact]
        public void ShouldCatchDirectoryChange()
        {
            this.shared.ViewModel.SelectedDirectory = string.Empty;
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(this.shared.ExpectedDirectory);

            Assert.NotEqual(this.shared.ExpectedDirectory, this.shared.ViewModel.SelectedDirectory);

            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.ConfigDirectoryChangeArgs);

            Assert.Equal(this.shared.ExpectedDirectory, this.shared.ViewModel.SelectedDirectory);
        }

        [Fact]
        public void ShouldCatchNameChange()
        {
            this.shared.ViewModel.SelectedDirectory = string.Empty;
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(this.shared.ExpectedName);

            Assert.NotEqual(this.shared.ExpectedName, this.shared.ViewModel.ConfigName);

            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.ConfigNameChangeArgs);

            Assert.Equal(this.shared.ExpectedName, this.shared.ViewModel.ConfigName);
        }
    }
}
