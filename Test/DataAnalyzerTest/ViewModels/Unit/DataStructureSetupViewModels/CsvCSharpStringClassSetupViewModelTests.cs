using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerTest.Utilities;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit.DataStructureSetupViewModels
{
    public class CsvCSharpStringClassSetupViewModelTests : IClassFixture<CsvCSharpStringClassSetupViewModelFixture>
    {
        private readonly CsvCSharpStringClassSetupViewModelFixture shared;

        public CsvCSharpStringClassSetupViewModelTests(CsvCSharpStringClassSetupViewModelFixture sharedData)
        {
            this.shared = sharedData;
            this.shared.MockConfigurationModel = new();
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(string.Empty);
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(string.Empty);

            this.shared.MockMainModel = new();
            this.shared.MockMainModel.Setup(x => x.LoadedDataStructure).Returns(Mock.Of<ILoadedDataStructure>());
            this.shared.MockMainModel.Setup(x => x.LoadedDataContent).Returns(Mock.Of<ILoadedDataContent>());
            this.shared.MockMainModel.Setup(x => x.LoadedInputFiles).Returns(Mock.Of<ILoadedInputFiles>());

            this.shared.MockStatsModel = new();
            this.shared.MockDefaultSetupViewModel = new();
            this.shared.MockCsvCSharpStringClassSetupModel = new();
            this.shared.MockDataConfiguration = new();

            this.shared.MockCsvCSharpStringClassSetupModel
                .Setup(x => x.DataConfiguration)
                .Returns(new CsvNamesDataConfiguration());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReportInvalidWhenClassNameNotSet(string className)
        {
            this.CreateViewModel();
            this.shared.ViewModel.ClassName = className;

            bool isValid = this.shared.ViewModel.IsValidSetup(out string reason);
            Assert.False(isValid);
            Assert.Equal("Class Name cannot be left empty", reason);
        }

        [Fact]
        public void ShouldReportvalidWhenClassNameSet()
        {
            this.CreateViewModel();
            this.shared.ViewModel.ClassName = "AValidClassName";

            bool isValid = this.shared.ViewModel.IsValidSetup(out string reason);
            Assert.True(isValid);
            Assert.Equal("", reason);
        }

        [Fact]
        public void ShouldLoadDataFromConfigurationModel()
        {
            const string expectedConfigName = "MyName";
            const string expectedConfigClassName = "MyClassName";
            List<(string CsvName, string PropertyName, bool Include)> expectedNewValues = this.GetPropertyRowData();

            this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name = expectedConfigName;
            this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.ClassName = expectedConfigClassName;
            this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties = expectedNewValues;

            this.CreateViewModel();
            this.shared.ViewModel.CsvPropertyRows.Add(new StringPropertyRowViewModel() { CsvName = "Bad", });

            this.shared.ViewModel.LoadViewModelFromConfiguration();

            AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows.Where(x => x.CsvName.Equals("Bad")), 0);
            AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows, 3);
            for (int i = 0; i < this.shared.ViewModel.CsvPropertyRows.Count; i++)
            {
                Assert.Equal(expectedNewValues[i].CsvName, this.shared.ViewModel.CsvPropertyRows[i].CsvName);
                Assert.Equal(expectedNewValues[i].PropertyName, this.shared.ViewModel.CsvPropertyRows[i].PropertyName);
                Assert.Equal(expectedNewValues[i].Include, this.shared.ViewModel.CsvPropertyRows[i].Include);
            }
        }

        [Fact]
        public void ShouldCreateAndApplyNewConfiguration()
        {
            const string expectedConfigName = "MyName";
            const string expectedConfigClassName = "MyClassName";
            List<(string CsvName, string PropertyName, bool Include)> expectedConfigProperties = this
                .GetPropertyRowData()
                .Where(x => x.Include)
                .ToList();

            this.CreateViewModel();
            this.shared.ViewModel.ConfigurationName = expectedConfigName;
            this.shared.ViewModel.ClassName = expectedConfigClassName;
            this.shared.ViewModel.CsvPropertyRows =
                new ObservableCollection<IStringPropertyRowViewModel>(this.GetPropertyRows());

            this.shared.ViewModel.ApplyConfiguration();

            this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.CreateNewDataConfiguration(), Times.Once);
            Assert.Equal(expectedConfigName, this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name);
            Assert.Equal(expectedConfigClassName, this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.ClassName);
            AssertionExtensions.CountIs(
                this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties,
                expectedConfigProperties.Count);
            AssertionExtensions.SequenceEqual(
                expectedConfigProperties,
                this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties,
                (a, b) =>
                    a.CsvName.Equals(b.CsvName) &&
                    a.PropertyName.Equals(b.PropertyName) &&
                    a.Include.Equals(b.Include));
        }

        [Fact]
        public void ShouldUseModelToSaveConfiguration()
        {
            this.CreateViewModel();
            this.shared.ViewModel.SaveConfiguration();
            this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.SaveConfiguration(), Times.Once);
        }

        [Fact]
        public void ShouldInitializeCsvNamesFromStats()
        {
            List<string> expectedNames = new[] { "A", "B", "C" }.ToList();
            this.shared.MockStatsModel.Setup(x => x.Stats).Returns(new List<IStats>()
            {
                new CsvNamesStats() { CsvNames = new(expectedNames)}
            });

            this.CreateViewModel();
            this.shared.ViewModel.CsvPropertyRows.Add(new StringPropertyRowViewModel() { CsvName = "Bad", });

            this.shared.ViewModel.Initialize();

            AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows.Where(x => x.CsvName.Equals("Bad")), 0);
            AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows, 3);
            for (int i = 0; i < this.shared.ViewModel.CsvPropertyRows.Count; i++)
            {
                Assert.Equal(expectedNames[i], this.shared.ViewModel.CsvPropertyRows[i].CsvName);
                Assert.Equal(expectedNames[i], this.shared.ViewModel.CsvPropertyRows[i].PropertyName);
                Assert.True(this.shared.ViewModel.CsvPropertyRows[i].Include);
            }
        }

        [Fact]
        public void ShouldGetCorrectDisplayString()
        {
            this.CreateViewModel();
            Assert.Equal(
                nameof(StructureExecutiveCommissioner.DisplayCsvToClassSetup),
                this.shared.ViewModel.GetDisplayStringName());
        }

        private List<(string CsvName, string PropertyName, bool Include)> GetPropertyRowData() => new()
        {
            ("Name1", "Property1", true),
            ("Name2", "Property2", false),
            ("Name1", "Property1", true),
        };

        private List<IStringPropertyRowViewModel> GetPropertyRows() => this
            .GetPropertyRowData()
            .Select(x => new StringPropertyRowViewModel()
            {
                CsvName = x.CsvName,
                PropertyName = x.PropertyName,
                Include = x.Include,
            })
            .Cast<IStringPropertyRowViewModel>()
            .ToList();

        private void CreateViewModel() =>
                this.shared.ViewModel = new(
                    this.shared.MockConfigurationModel.Object,
                    this.shared.MockMainModel.Object,
                    this.shared.MockStatsModel.Object,
                    this.shared.MockDefaultSetupViewModel.Object,
                    this.shared.MockCsvCSharpStringClassSetupModel.Object);
    }
}
