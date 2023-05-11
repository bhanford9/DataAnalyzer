using DataAnalyzer.Models;
using DataAnalyzer.Services.Enums;
using DataAnalyzerFixtures.ViewModels;
using Moq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit;

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
            .Setup(x => x.ImportExecutionKey)
            .Returns(this.shared.MockKey.Object);
    }

    [Fact]
    public void ShouldCatchConfigurationKeyChange()
    {
        ExecutionType expectedExecutionType = ExecutionType.Excel;

        this.CreateViewModel();
        this.shared.ViewModel.SelectedExecutionType = ExecutionType.NotApplicable.ToString();
        this.shared.MockConfigurationModel.Setup(x => x.SelectedExecutionType).Returns(expectedExecutionType);

        this.shared.MockConfigurationModel.Raise(
            this.shared.GetEventAction<IConfigurationModel>(),
            this.shared.ConfigKeyChangeArgs);

        this.shared.MockExecutiveCommissioner.Verify(x => x.SetDisplay(), Times.Once);
        Assert.Equal(expectedExecutionType.ToString(), this.shared.ViewModel.SelectedExecutionType);
    }

    private void CreateViewModel() =>
        this.shared.ViewModel = new(
            this.shared.MockConfigurationModel.Object,
            this.shared.MockExecutiveCommissioner.Object);
}
