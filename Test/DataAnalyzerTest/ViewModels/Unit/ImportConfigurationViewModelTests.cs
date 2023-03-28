using DataAnalyzer.Models;
using DataAnalyzerFixtures.ViewModels;
using DataAnalyzerTest.Utilities;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ImportConfigurationViewModelTests : IClassFixture<ImportConfigurationViewModelFixture>
    {
        private readonly ImportConfigurationViewModelFixture shared;

        public ImportConfigurationViewModelTests(ImportConfigurationViewModelFixture shared)
        {
            this.shared = shared;
            this.shared.MockConfigurationModel = new();
            this.shared.MockExecutiveCommissioner = new();
            this.shared.MockDataConverters = new();
        }

        [Fact]
        public void ShouldInitializeImportTypesOnCreation()
        {
            this.shared.MockDataConverters
                .Setup(x => x.GetImportTypes())
                .Returns(new List<IImportType>
                {
                    Mock.Of<IImportType>(),
                    Mock.Of<IImportType>(),
                    Mock.Of<IImportType>(),
                });

            this.CreateViewModel();

            this.shared.MockDataConverters.Verify(x => x.GetImportTypes(), Times.Once());
            AssertionExtensions.CountIs(this.shared.ViewModel.ImportTypes, 3);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldNotApplyConfigurationUnlessLoadedOnCreation(bool hasLoaded)
        {
            NotApplicableImportType defaultImport = new();
            NotApplicableScraperCategory defaultCategory = new();
            NotApplicableScraperFlavor defaultFlavor = new();

            FileImportType actualImport = new();
            CsvNamesScraperCategory actualCategory = new();
            CsvNamesStandardScraperFlavor actualFlavor = new();

            this.shared.MockConfigurationModel.Setup(x => x.HasLoaded).Returns(hasLoaded);
            this.shared.MockConfigurationModel.Setup(x => x.ImportType).Returns(actualImport);
            this.shared.MockConfigurationModel.Setup(x => x.Category).Returns(actualCategory);
            this.shared.MockConfigurationModel.Setup(x => x.Flavor).Returns(actualFlavor);

            this.CreateViewModel();

            if (hasLoaded)
            {
                Assert.IsType(this.shared.ViewModel.SelectedImportType.GetType(), actualImport);
                Assert.IsType(this.shared.ViewModel.SelectedScraperCategory.GetType(), actualCategory);
                Assert.IsType(this.shared.ViewModel.SelectedScraperFlavor.GetType(), actualFlavor);
                this.shared.MockExecutiveCommissioner.Verify(x => x.SetDisplay(), Times.Once);
            }
            else
            {
                Assert.IsType(this.shared.ViewModel.SelectedImportType.GetType(), defaultImport);
                Assert.IsType(this.shared.ViewModel.SelectedScraperCategory.GetType(), defaultCategory);
                Assert.IsType(this.shared.ViewModel.SelectedScraperFlavor.GetType(), defaultFlavor);
                this.shared.MockExecutiveCommissioner.Verify(x => x.SetDisplay(), Times.Never);
            }
        }

        [Fact]
        public void ShouldInitializeSettingsWhenSettingSelectedImportType()
        {
            IImportType importType = Mock.Of<IImportType>();
            Mock<IScraperCategory> category1 = new();
            Mock<IScraperCategory> category2 = new();
            category1.Setup(x => x.Name).Returns("One");
            category2.Setup(x => x.Name).Returns("Two");
            List<IScraperCategory> categories = new List<IScraperCategory>()
            {
                category1.Object,
                category2.Object,
            };

            this.shared.MockDataConverters.Setup(x => x.GetCategories(importType, true)).Returns(categories);

            this.CreateViewModel();
            this.shared.ViewModel.CategoryIsSelectable = false;

            this.shared.ViewModel.SelectedImportType = importType;

            this.shared.MockDataConverters.Verify(x => x.GetCategories(importType, true), Times.Once);

            Assert.Equal(importType, this.shared.ViewModel.SelectedImportType);
            Assert.True(this.shared.ViewModel.CategoryIsSelectable);
            Assert.Collection(
                this.shared.ViewModel.ScraperCategories,
                (x) => x.Name.Equals("One"),
                (x) => x.Name.Equals("Two"));
            this.shared.MockConfigurationModel.VerifySet(x => x.ImportType = importType, Times.Once);
        }

        [Fact]
        public void ShouldInitializeSettingsWhenSettingSelectedCategory()
        {
            IImportType importType = Mock.Of<IImportType>();
            IScraperCategory category = Mock.Of<IScraperCategory>();
            Mock<IScraperFlavor> flavor1 = new();
            Mock<IScraperFlavor> flavor2 = new();
            flavor1.Setup(x => x.Name).Returns("One");
            flavor2.Setup(x => x.Name).Returns("Two");
            List<IScraperFlavor> flavors = new List<IScraperFlavor>()
            {
                flavor1.Object,
                flavor2.Object,
            };

            this.shared.MockDataConverters.Setup(x => x.GetFlavors(importType, category, true)).Returns(flavors);

            this.CreateViewModel();
            this.shared.ViewModel.SelectedImportType = importType;
            this.shared.ViewModel.FlavorIsSelectable = false;

            this.shared.ViewModel.SelectedScraperCategory = category;

            this.shared.MockDataConverters.Verify(x => x.GetFlavors(importType, category, true), Times.Once);

            Assert.Equal(category, this.shared.ViewModel.SelectedScraperCategory);
            Assert.True(this.shared.ViewModel.FlavorIsSelectable);
            Assert.Collection(
                this.shared.ViewModel.ScraperFlavors,
                (x) => x.Name.Equals("One"),
                (x) => x.Name.Equals("Two"));
            this.shared.MockConfigurationModel.VerifySet(x => x.Category = category, Times.Once);
        }

        [Fact]
        public void ShouldSetConfigFlavorWhenSettingSelectedFlavor()
        {
            Mock<IScraperFlavor> expectedFlavor = new();
            expectedFlavor.Setup(x => x.Name).Returns("MyFlavor");
            this.CreateViewModel();
            
            this.shared.ViewModel.SelectedScraperFlavor = expectedFlavor.Object;

            Assert.Equal(expectedFlavor.Object, this.shared.ViewModel.SelectedScraperFlavor);
            this.shared.MockConfigurationModel.VerifySet(x => x.Flavor = expectedFlavor.Object, Times.Once);
        }

        [Fact]
        public void ShouldReceiveImportTypeChangeFromConfigModel()
        {
            Mock<IImportType> previous = new();
            previous.Setup(x => x.Name).Returns("previous");
            Mock<IImportType> updated = new();
            updated.Setup(x => x.Name).Returns("updated");

            this.CreateViewModel();
            this.shared.ViewModel.SelectedImportType = previous.Object;

            Assert.NotEqual(updated.Object, this.shared.ViewModel.SelectedImportType);

            this.shared.MockConfigurationModel.Setup(x => x.ImportType).Returns(updated.Object);
            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.ImportChangeArgs);

            Assert.Equal(updated.Object, this.shared.ViewModel.SelectedImportType);
        }

        [Fact]
        public void ShouldReceiveCategoryChangeFromConfigModel()
        {
            Mock<IScraperCategory> previous = new();
            previous.Setup(x => x.Name).Returns("previous");
            Mock<IScraperCategory> updated = new();
            updated.Setup(x => x.Name).Returns("updated");

            this.CreateViewModel();
            this.shared.ViewModel.SelectedScraperCategory = previous.Object;

            Assert.NotEqual(updated.Object, this.shared.ViewModel.SelectedScraperCategory);

            this.shared.MockConfigurationModel.Setup(x => x.Category).Returns(updated.Object);
            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.CategoryChangeArgs);

            Assert.Equal(updated.Object, this.shared.ViewModel.SelectedScraperCategory);
        }

        [Fact]
        public void ShouldReceiveFlavorChangeFromConfigModel()
        {
            Mock<IScraperFlavor> previous = new();
            previous.Setup(x => x.Name).Returns("previous");
            Mock<IScraperFlavor> updated = new();
            updated.Setup(x => x.Name).Returns("updated");

            this.CreateViewModel();
            this.shared.ViewModel.SelectedScraperFlavor = previous.Object;

            Assert.NotEqual(updated.Object, this.shared.ViewModel.SelectedScraperFlavor);

            this.shared.MockConfigurationModel.Setup(x => x.Flavor).Returns(updated.Object);
            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.FlavorChangeArgs);

            Assert.Equal(updated.Object, this.shared.ViewModel.SelectedScraperFlavor);
        }

        private void CreateViewModel() =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object,
                this.shared.MockDataConverters.Object);
    }
}
