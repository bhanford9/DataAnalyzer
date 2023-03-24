using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerTest.Fixtures.ViewModels;
using Moq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ConfigurationCreationViewModelTests : IClassFixture<ConfigurationCreationViewModelFixture>
    {
        private readonly ConfigurationCreationViewModelFixture shared;

        public ConfigurationCreationViewModelTests(ConfigurationCreationViewModelFixture shared)
        {
            this.shared = shared;
            this.shared.MockConfigurationModel = new();
            this.shared.MockExecutiveCommissioner = new();
        }


        // Need to make sure the initialize method within the class's constructor properly gets everything from
        // the main/config/stats models and initializes itself

        //    if (this.configModel.ImportExportKey.IsValid)
        //    {
        //        this.ActiveViewModel = this.MockExecutiveCommissioner.GetInitializedViewModel();
        //        this.ApplyConfigurationDirectory(this.MockExecutiveCommissioner.GetConfigurationDirectory());
        //    }

        //    this.MockExecutiveCommissioner.SetDisplay();

        [Fact]
        public void ShouldSetDisplayToNotApplicableIfNothingSelectedAtConstruction()
        {
            this.shared.MockConfigurationModel.Setup(x => x.ImportExportKey).Returns(ImportExportKey.Default);

            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object);

            Assert.IsType(new NotSupportedSetupViewModel(new()).GetType(), this.shared.ViewModel.ActiveViewModel);
            this.shared.MockExecutiveCommissioner.Verify(x => x.GetInitializedViewModel(), Times.Never);
            this.shared.MockExecutiveCommissioner.Verify(x => x.GetConfigurationDirectory(), Times.Never);
        }

        [Fact]
        public void ShouldNotApplyConfigurationDirectoryIfInvalidAtConstruction()
        {

        }

        [Fact]
        public void ShouldSetActiveViewModelIfValidAtConstruction()
        {

        }

        [Fact]
        public void ShouldApplyConfigurationDirectoryIfValidAtConstruction()
        {

        }
    }
}
