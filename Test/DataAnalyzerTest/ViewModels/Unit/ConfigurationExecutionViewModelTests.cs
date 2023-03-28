using DataAnalyzer.Models;
using DataAnalyzer.Services.Enums;
using DataAnalyzerFixtures.ViewModels;
using Moq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ConfigurationExecutionViewModelTests : IClassFixture<ConfigurationExecutionViewModelFixture>
    {
        private readonly ConfigurationExecutionViewModelFixture shared;

        public ConfigurationExecutionViewModelTests(ConfigurationExecutionViewModelFixture shared)
        {
            this.shared = shared;
            this.shared.MockConfigurationModel = new();
            this.shared.MockExecutiveCommissioner = new();
            this.shared.MockKey = new();
            this.shared.MockConfigurationModel
                .Setup(x => x.ImportExportKey)
                .Returns(this.shared.MockKey.Object);
        }

        [Fact]
        public void ShouldCatchConfigurationKeyChange()
        {
            ExportType expectedExportType = ExportType.Excel;

            this.CreateViewModel();
            this.shared.ViewModel.SelectedExportType = ExportType.NotApplicable.ToString();
            this.shared.MockConfigurationModel.Setup(x => x.SelectedExportType).Returns(expectedExportType);

            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.ConfigKeyChangeArgs);

            this.shared.MockExecutiveCommissioner.Verify(x => x.SetDisplay(), Times.Once);
            Assert.Equal(expectedExportType.ToString(), this.shared.ViewModel.SelectedExportType);
        }

        private void CreateViewModel() =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object);
    }
}
