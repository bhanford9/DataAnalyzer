using DataAnalyzer.Models;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerFixtures.ViewModels;
using Moq;
using System;
using System.IO;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ConfigurationCreationViewModelTests : IClassFixture<ConfigurationCreationViewModelFixture>
    {
        private readonly ConfigurationCreationViewModelFixture shared;

        public ConfigurationCreationViewModelTests(ConfigurationCreationViewModelFixture shared)
        {
            this.shared = shared;
            this.shared.MockMainModel = new();
            this.shared.MockConfigurationModel = new();
            this.shared.MockExecutiveCommissioner = new();
            this.shared.MockKey = new();
            this.shared.MockConfigurationModel
                .Setup(x => x.ImportExportKey)
                .Returns(this.shared.MockKey.Object);
            this.shared.MockDefaultView = new();
            this.shared.MockNotSupportedSetupModel = new();
        }

        [Fact]
        public void ShouldSetDisplayToNotApplicableIfNothingSelectedAtConstruction()
        {
            this.shared.MockConfigurationModel.Setup(x => x.ImportExportKey).Returns(ImportExportKey.Default);

            this.CreateViewModel();

            Assert.True(this.shared.ViewModel.ActiveViewModel
                .GetType()
                .IsAssignableTo(typeof(INotSupportedSetupViewModel)));

            Assert.Empty(this.shared.ViewModel.Configurations);
            this.shared.MockExecutiveCommissioner.Verify(x => x.GetInitializedViewModel(), Times.Never);
            this.shared.MockExecutiveCommissioner.Verify(x => x.GetConfigurationDirectory(), Times.Never);
            this.shared.MockExecutiveCommissioner.Verify(x => x.CreateNewDataConfiguration(), Times.Never);

            // Integration tests should verify the following get set. Can't do so with a mock
            //this.shared.MockExecutiveCommissioner.VerifySet(x => x.DisplayCsvToClassSetup = false);
            //this.shared.MockExecutiveCommissioner.VerifySet(x => x.DisplayGroupingSetup = false);
            //this.shared.MockExecutiveCommissioner.VerifySet(x => x.DisplayNotSupported = true);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldSetActiveViewModelIfValidAtConstruction(bool isDefault)
        {
            var configDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "TestConfigs");

            string expectedExportType = ExportType.CSharpTypedProperties.ToString();

            this.shared.MockKey.Setup(x => x.IsValid).Returns(true);

            Mock<IDataStructureSetupViewModel> mockDataStructureSetupViewModel = new();
            mockDataStructureSetupViewModel.Setup(x => x.IsDefault).Returns(isDefault);

            this.shared.MockExecutiveCommissioner
                .Setup(x => x.GetConfigurationDirectory())
                .Returns(configDirectory);
            this.shared.MockExecutiveCommissioner
                .Setup(x => x.GetInitializedViewModel())
                .Returns(mockDataStructureSetupViewModel.Object);
            this.shared.MockExecutiveCommissioner
                .Setup(x => x.SelectedExportType)
                .Returns(expectedExportType);

            this.CreateViewModel();

            this.shared.MockExecutiveCommissioner.Verify(x => x.GetInitializedViewModel(), Times.Once);
            Assert.Equal(mockDataStructureSetupViewModel.Object, this.shared.ViewModel.ActiveViewModel);

            if (!isDefault)
            {
                this.shared.MockExecutiveCommissioner.Verify(x => x.GetConfigurationDirectory(), Times.Once);
            }

            Assert.True(Directory.Exists(configDirectory));
        }

        [Fact]
        public void ShouldClearAndCreateConfig()
        {
            this.CreateViewModel();

            this.shared.ViewModel.CreateConfiguration.Execute(null);

            this.shared.MockExecutiveCommissioner.VerifySet(x => x.DisplayNotSupported = false, Times.Once);
            this.shared.MockExecutiveCommissioner.Verify(x => x.ClearConfiguration(), Times.Once);
            this.shared.MockExecutiveCommissioner.Verify(x => x.CreateNewDataConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldCancelChanges()
        {
            this.CreateViewModel();

            this.shared.ViewModel.CancelChanges.Execute(null);

            this.shared.MockExecutiveCommissioner.VerifySet(x => x.DisplayNotSupported = true, Times.Once);
            this.shared.MockExecutiveCommissioner.Verify(x => x.ClearConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldNotApplyConifgurationWithoutName()
        {
            this.CreateViewModel();
            this.shared.MockExecutiveCommissioner.Setup(x => x.GetConfigurationName()).Returns("");

            this.shared.ViewModel.ApplyWithoutSave.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Never);
        }

        [Fact]
        public void ShouldNotApplyConfigurationIfInvalidSetup()
        {
            this.CreateViewModel();

            string reason = string.Empty;
            this.shared.MockExecutiveCommissioner.Setup(x => x.IsValidSetup(out reason)).Returns(false);

            this.shared.ViewModel.ApplyWithoutSave.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Never);
        }

        [Fact]
        public void ShouldApplyConfiguration()
        {
            this.CreateViewModel();

            string reason = string.Empty;
            this.shared.MockExecutiveCommissioner.Setup(x => x.IsValidSetup(out reason)).Returns(true);
            this.shared.MockExecutiveCommissioner.Setup(x => x.GetConfigurationName()).Returns("Name");

            this.shared.ViewModel.ApplyWithoutSave.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldNotApplyNorSaveConifgurationWithoutName()
        {
            this.CreateViewModel();
            this.shared.MockExecutiveCommissioner.Setup(x => x.GetConfigurationName()).Returns("");

            this.shared.ViewModel.SaveConfiguration.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Never);
            this.shared.MockExecutiveCommissioner.Verify(x => x.SaveConfiguration(), Times.Never);
        }

        [Fact]
        public void ShouldNotApplyNorSaveConfigurationIfInvalidSetup()
        {
            this.CreateViewModel();

            string reason = string.Empty;
            this.shared.MockExecutiveCommissioner.Setup(x => x.IsValidSetup(out reason)).Returns(false);

            this.shared.ViewModel.SaveConfiguration.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Never);
            this.shared.MockExecutiveCommissioner.Verify(x => x.SaveConfiguration(), Times.Never);
        }

        [Fact]
        public void ShouldApplyAndSaveConfiguration()
        {
            this.CreateViewModel();

            string reason = string.Empty;
            this.shared.MockExecutiveCommissioner.Setup(x => x.IsValidSetup(out reason)).Returns(true);
            this.shared.MockExecutiveCommissioner.Setup(x => x.GetConfigurationName()).Returns("Name");

            this.shared.ViewModel.SaveConfiguration.Execute(null);

            this.shared.MockExecutiveCommissioner.Verify(x => x.ApplyConfiguration(), Times.Once);
            this.shared.MockExecutiveCommissioner.Verify(x => x.SaveConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldCatchConfigurationKeyChange()
        {
            this.CreateViewModel();
            this.shared.MockKey.Invocations.Clear();
            this.shared.MockExecutiveCommissioner.Invocations.Clear();
            
            this.shared.MockKey.Setup(x => x.IsValid).Returns(false);

            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.ConfigKeyChangeArgs);

            this.shared.MockKey.Verify(x => x.IsValid, Times.Once);
            this.shared.MockExecutiveCommissioner.Verify(x => x.SetDisplay(), Times.Once);
        }

        private void CreateViewModel() =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object,
                this.shared.MockDefaultView.Object);
    }
}
