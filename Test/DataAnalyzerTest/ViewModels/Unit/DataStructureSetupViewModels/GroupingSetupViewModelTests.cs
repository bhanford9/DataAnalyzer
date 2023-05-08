using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerTest.Utilities;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using Moq;
using Xunit;
using DataAnalyzerTest.ViewModels.Builders;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;
using System.Collections.Generic;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.Models.DataStructureSetupModels;

namespace DataAnalyzerTest.ViewModels.Unit.DataStructureSetupViewModels
{
    public class GroupingSetupViewModelTests : IClassFixture<GroupingSetupViewModelFixture>
    {
        private readonly GroupingSetupViewModelFixture shared;

        public GroupingSetupViewModelTests(GroupingSetupViewModelFixture sharedData)
        {
            this.shared = sharedData;
            this.shared.MockConfigurationModel = new();
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(string.Empty);
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(string.Empty);

            this.shared.MockStatsModel = new();

            this.shared.MockMainModel = new();
            this.shared.MockMainModel.Setup(x => x.LoadedDataStructure).Returns(Mock.Of<ILoadedDataStructure>());
            this.shared.MockMainModel.Setup(x => x.LoadedDataContent).Returns(Mock.Of<ILoadedDataContent>());
            this.shared.MockMainModel.Setup(x => x.LoadedInputFiles).Returns(Mock.Of<ILoadedInputFiles>());

            this.shared.MockDefaultSetupViewModel = new();
            this.shared.MockGroupingSetupModel = new();
            this.shared.MockDataConfiguration = new();

            this.shared.MockGroupingSetupModel
                .Setup(x => x.DataConfiguration)
                .Returns(new GroupingDataConfiguration());
        }

        [Fact]
        public void ShouldAddGroupingsWhenCountIsGreaterThanExisting()
        {
            const int expectedCount = 3;
            this.CreateViewModel();
            this.shared.ViewModel.GroupingLayersCount = expectedCount;

            this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Once());
            Assert.Equal(expectedCount, this.shared.MockMainModel.Object.LoadedDataStructure.GroupingsCount);
            AssertionExtensions.CountIs(this.shared.ViewModel.ConfigurationGroupings, expectedCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldRemoveGroupingsWhenCountIsLessThanExisting(int input)
        {
            int expectedCount = input < 0 ? 0 : input;
            this.CreateViewModel();
            this.shared.ViewModel.ConfigurationGroupings.Add(
                new ConfigurationGroupingViewModel(
                    this.shared.MockStatsModel.Object,
                    this.shared.MockConfigurationModel.Object,
                    this.shared.ViewModel,
                    0));
            this.shared.ViewModel.ConfigurationGroupings.Add(
                new ConfigurationGroupingViewModel(
                    this.shared.MockStatsModel.Object,
                    this.shared.MockConfigurationModel.Object,
                    this.shared.ViewModel,
                    1));
            this.shared.ViewModel.ConfigurationGroupings.Add(
                new ConfigurationGroupingViewModel(
                    this.shared.MockStatsModel.Object,
                    this.shared.MockConfigurationModel.Object,
                    this.shared.ViewModel,
                    2));
            this.shared.ViewModel.GroupingLayersCount = expectedCount;

            this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Once());
            Assert.Equal(expectedCount, this.shared.MockMainModel.Object.LoadedDataStructure.GroupingsCount);
            AssertionExtensions.CountIs(this.shared.ViewModel.ConfigurationGroupings, expectedCount);
        }

        //public bool IsValid =>
        //    ImportKey.Type is not NotApplicableImportType &&
        //    ImportKey.Category is not NotApplicableScraperCategory &&
        //    ImportKey.Flavor is not NotApplicableScraperFlavor &&
        //    this.ExecutionType != ExecutionType.NotApplicable;

        [Fact]
        public void ShouldReturnTrueWithEmptyStringWhenDataTypeIsValid()
        {
            this.CreateViewModel();
            this.shared.ViewModel.SelectedDataType = this.GetValidImportExecutionKey();

            bool result = this.shared.ViewModel.IsValidSetup(out string reason);

            Assert.True(result);
            Assert.Equal(string.Empty, reason);
        }

        [Fact]
        public void ShouldReturnFalseWithMessageWhenDataTypeIsInvalid()
        {
            this.CreateViewModel();
            this.shared.ViewModel.SelectedDataType = this.GetInvalidImportExecutionKey();

            bool result = this.shared.ViewModel.IsValidSetup(out string reason);

            Assert.False(result);
            Assert.Equal("Must have selected Data Type", reason);
        }

        [Fact]
        public void ShouldClearConfiguration()
        {
            this.CreateViewModel();
            this.shared.ViewModel.ClearConfiguration();

            Assert.Equal(ImportExecutionKey.Default, this.shared.ViewModel.SelectedDataType);
            Assert.Equal(0, this.shared.ViewModel.GroupingLayersCount);
            Assert.Empty(this.shared.ViewModel.ConfigurationGroupings);
        }

        [Fact]
        public void ShouldLoadViewModelFromConfiguration()
        {
            const string expectedName = "MyName";
            const int expectedCount = 3;
            const string GroupName = "Group";
            const string ParamName = "Param";

            var groupConfig1 = new Mock<IGroupingConfiguration>();
            groupConfig1.Setup(x => x.GroupName).Returns($"{GroupName}1");
            groupConfig1.Setup(x => x.SelectedParameter).Returns($"{ParamName}1");
            var groupConfig2 = new Mock<IGroupingConfiguration>();
            groupConfig2.Setup(x => x.GroupName).Returns($"{GroupName}2");
            groupConfig2.Setup(x => x.SelectedParameter).Returns($"{ParamName}2");
            var groupConfig3 = new Mock<IGroupingConfiguration>();
            groupConfig3.Setup(x => x.GroupName).Returns($"{GroupName}3");
            groupConfig3.Setup(x => x.SelectedParameter).Returns($"{ParamName}3");

            this.shared.MockGroupingSetupModel.Object.DataConfiguration.Name = expectedName;
            this.shared.MockGroupingSetupModel.Object.DataConfiguration.GroupingConfiguration =
                new List<IGroupingConfiguration>()
                {
                    groupConfig1.Object,
                    groupConfig2.Object,
                    groupConfig3.Object,
                };

            this.CreateViewModel();

            this.shared.ViewModel.LoadViewModelFromConfiguration();

            Assert.Equal(expectedName, this.shared.ViewModel.ConfigurationName);
            Assert.Equal(expectedCount, this.shared.ViewModel.GroupingLayersCount);
            AssertionExtensions.CountIs(this.shared.ViewModel.ConfigurationGroupings, expectedCount);

            for (int i = 0; i < expectedCount; i++)
            {
                Assert.Equal($"{GroupName}{i + 1}", this.shared.ViewModel.ConfigurationGroupings[i].Name);
                Assert.Equal($"{ParamName}{i + 1}", this.shared.ViewModel.ConfigurationGroupings[i].SelectedParameter);
            }
        }

        [Fact]
        public void ShouldApplyConfigurationToModel()
        {
            const string expectedConfigName = "MyConfig";
            const int expectedCount = 3;
            const string GroupName = "Group";
            const string ParamName = "Param";

            this.CreateViewModel();
            this.shared.ViewModel.ConfigurationName = expectedConfigName;
            for (int i = 0; i < 3; i++)
            {
                this.shared.ViewModel.ConfigurationGroupings.Add(new ConfigurationGroupingViewModel(
                    this.shared.MockStatsModel.Object,
                    this.shared.MockConfigurationModel.Object,
                    this.shared.ViewModel,
                    i)
                {
                    Name = $"{GroupName}{i}",
                    SelectedParameter = $"{ParamName}{i}",
                });
            }

            this.shared.ViewModel.ApplyConfiguration();

            this.shared.MockGroupingSetupModel.Verify(x => x.ClearGroupingConfigurations(), Times.Once);
            Assert.Equal(expectedConfigName, this.shared.MockGroupingSetupModel.Object.DataConfiguration.Name);
            this.shared.MockGroupingSetupModel.Verify(
                x => x.AddGroupingConfiguration(It.IsAny<IGroupingConfiguration>()),
                Times.Exactly(expectedCount));
        }

        [Fact]
        public void ShouldMapSaveToModel()
        {
            this.CreateViewModel();
            this.shared.ViewModel.SaveConfiguration();
            this.shared.MockGroupingSetupModel.Verify(x => x.SaveConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldMapRemoveGroupingConfigToModel()
        {
            this.CreateViewModel();
            this.shared.ViewModel.RemoveGroupingConfiguration(3);
            this.shared.MockGroupingSetupModel.Verify(x => x.RemoveGroupingConfiguration(3), Times.Once);
        }

        [Fact]
        public void ShouldGetDisplayStringName()
        {
            this.CreateViewModel();
            Assert.Equal(
                nameof(StructureExecutiveCommissioner.DisplayGroupingSetup),
                this.shared.ViewModel.GetDisplayStringName());
        }

        [Fact]
        public void ShouldUpdateGroupingsWhenModelRemovesLevel()
        {
            const int expectedCount = 2;
            const string GroupName = "Group";
            const string ParamName = "Param";

            this.CreateViewModel();
            this.shared.ViewModel.GroupingLayersCount = 3;

            for (int i = 0; i < 3; i++)
            {
                this.shared.ViewModel.ConfigurationGroupings[i].Name = $"{GroupName}{i}";
                this.shared.ViewModel.ConfigurationGroupings[i].SelectedParameter = $"{ParamName}{i}";
            }

            this.shared.MockGroupingSetupModel.Setup(x => x.RemoveLevel).Returns(1);
            this.shared.MockGroupingSetupModel.Raise(
                this.shared.GetEventAction<IGroupingSetupModel>(),
                this.shared.RemoveLevelChangeArgs);

            AssertionExtensions.CountIs(this.shared.ViewModel.ConfigurationGroupings, expectedCount);
            Assert.Equal(expectedCount, this.shared.ViewModel.GroupingLayersCount);

            Assert.Equal($"{GroupName}0", this.shared.ViewModel.ConfigurationGroupings[0].Name);
            Assert.Equal($"{GroupName}2", this.shared.ViewModel.ConfigurationGroupings[1].Name);
            Assert.Equal($"{ParamName}0", this.shared.ViewModel.ConfigurationGroupings[0].SelectedParameter);
            Assert.Equal($"{ParamName}2", this.shared.ViewModel.ConfigurationGroupings[1].SelectedParameter);
        }

        private IImportExecutionKey GetValidImportExecutionKey() => new ImportExecutionKeyBuilder()
            .With(
                new FileImportType(),
                new CsvNamesScraperCategory(),
                new CsvTestScraperFlavor(),
                ExecutionType.CSharpStringProperties)
            .Build();

        private IImportExecutionKey GetInvalidImportExecutionKey() => new ImportExecutionKeyBuilder().Build();

        private void CreateViewModel() =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockStatsModel.Object,
                this.shared.MockMainModel.Object,
                this.shared.MockDefaultSetupViewModel.Object,
                this.shared.MockGroupingSetupModel.Object);
    }
}
