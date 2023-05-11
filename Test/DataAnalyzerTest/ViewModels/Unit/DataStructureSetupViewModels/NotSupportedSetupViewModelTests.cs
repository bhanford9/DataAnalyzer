using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit.DataStructureSetupViewModels;

public class NotSupportedSetupViewModelTests : IClassFixture<NotSupportedSetupViewModelFixture>
{
    private readonly NotSupportedSetupViewModelFixture shared;

    public NotSupportedSetupViewModelTests(NotSupportedSetupViewModelFixture sharedData)
    {
        this.shared = sharedData;
        this.shared.MockConfigurationModel = new();
        this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(string.Empty);
        this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(string.Empty);
        
        this.shared.MockStatsModel = new();
        this.shared.MockMainModel = new();
        this.shared.MockDefaultSetupViewModel = new();
        this.shared.MockNotSupportedSetupModel = new();
    }

    [Fact]
    public void ShouldAlwaysReturnInvalidSetup()
    {
        this.CreateViewModel();
        bool result = this.shared.ViewModel.IsValidSetup(out string reason);
        Assert.False(result);
        Assert.Equal("Configuration not supported", reason);
    }

    [Fact]
    public void ShouldGetDisplayStringName()
    {
        this.CreateViewModel();
        Assert.Equal(
            nameof(StructureExecutiveCommissioner.DisplayNotSupported),
            this.shared.ViewModel.GetDisplayStringName());
    }

    private void CreateViewModel() =>
        this.shared.ViewModel = new(
            this.shared.MockConfigurationModel.Object,
            this.shared.MockStatsModel.Object,
            this.shared.MockMainModel.Object,
            this.shared.MockNotSupportedSetupModel.Object);
}
