using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Models.LoadedConfigurations;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;
using DataAnalyzerTest.Utilities;
using DataAnalyzerTest.ViewModels.Builders;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors.CsvFlavors;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit.DataStructureSetupViewModels;

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
            .Returns(new ClassCollectionSetupConfiguration());
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

    //[Fact]
    //public void ShouldLoadDataFromConfigurationModel()
    //{
    //    const string expectedConfigName = "MyName";
    //    const string expectedConfigClassName = "MyClassName";
    //    List<(string CsvName, string PropertyName, bool Include)> expectedNewValues = this.GetPropertyRowData();

    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name = expectedConfigName;
    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.ClassName = expectedConfigClassName;
    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties = expectedNewValues;

    //    this.CreateViewModel();
    //    this.shared.ViewModel.CsvPropertyRows.Add(new StringPropertyRowViewModel() { SerializedName = "Bad", });

    //    this.shared.ViewModel.LoadViewModelFromConfiguration();

    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows.Where(x => x.SerializedName.Equals("Bad")), 0);
    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows, 3);
    //    for (int i = 0; i < this.shared.ViewModel.CsvPropertyRows.Count; i++)
    //    {
    //        Assert.Equal(expectedNewValues[i].CsvName, this.shared.ViewModel.CsvPropertyRows[i].SerializedName);
    //        Assert.Equal(expectedNewValues[i].PropertyName, this.shared.ViewModel.CsvPropertyRows[i].PropertyName);
    //        Assert.Equal(expectedNewValues[i].Include, this.shared.ViewModel.CsvPropertyRows[i].Include);
    //    }
    //}

    //[Fact]
    //public void ShouldCreateAndApplyNewConfiguration()
    //{
    //    const string expectedConfigName = "MyName";
    //    const string expectedConfigClassName = "MyClassName";
    //    List<(string CsvName, string PropertyName, bool Include)> expectedConfigProperties = this
    //        .GetPropertyRowData()
    //        .Where(x => x.Include)
    //        .ToList();

    //    this.CreateViewModel();
    //    this.shared.ViewModel.ConfigurationName = expectedConfigName;
    //    this.shared.ViewModel.ClassName = expectedConfigClassName;
    //    this.shared.ViewModel.CsvPropertyRows =
    //        new ObservableCollection<IStringPropertyRowViewModel>(this.GetPropertyRows());

    //    this.shared.ViewModel.ApplyConfiguration();

    //    this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.CreateNewDataConfiguration(), Times.Once);
    //    Assert.Equal(expectedConfigName, this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name);
    //    Assert.Equal(expectedConfigClassName, this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.ClassName);
    //    AssertionExtensions.CountIs(
    //        this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties,
    //        expectedConfigProperties.Count);
    //    AssertionExtensions.SequenceEqual(
    //        expectedConfigProperties,
    //        this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties,
    //        (a, b) =>
    //            a.CsvName.Equals(b.CsvName) &&
    //            a.PropertyName.Equals(b.PropertyName) &&
    //            a.Include.Equals(b.Include));
    //}

    [Fact]
    public void ShouldUseModelToSaveConfiguration()
    {
        this.CreateViewModel();
        this.shared.ViewModel.SaveConfiguration();
        this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.SaveConfiguration(), Times.Once);
    }

    //[Fact]
    //public void ShouldInitializeCsvNamesFromStats()
    //{
    //    List<string> expectedNames = new[] { "A", "B", "C" }.ToList();
    //    this.shared.MockStatsModel.Setup(x => x.Stats).Returns(new List<IStats>()
    //    {
    //        new CsvNamesStats() { CsvNames = new ComparableList<string>(expectedNames)}
    //    });

    //    this.CreateViewModel();
    //    this.shared.ViewModel.CsvPropertyRows.Add(new StringPropertyRowViewModel() { SerializedName = "Bad", });

    //    this.shared.ViewModel.Initialize();

    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows.Where(x => x.SerializedName.Equals("Bad")), 0);
    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows, 3);
    //    for (int i = 0; i < this.shared.ViewModel.CsvPropertyRows.Count; i++)
    //    {
    //        Assert.Equal(expectedNames[i], this.shared.ViewModel.CsvPropertyRows[i].SerializedName);
    //        Assert.Equal(expectedNames[i], this.shared.ViewModel.CsvPropertyRows[i].PropertyName);
    //        Assert.True(this.shared.ViewModel.CsvPropertyRows[i].Include);
    //    }
    //}

    [Fact]
    public void ShouldGetCorrectDisplayString()
    {
        this.CreateViewModel();
        Assert.Equal(
            nameof(StructureExecutiveCommissioner.DisplayCsvToClassSetup),
            this.shared.ViewModel.GetDisplayStringName());
    }

    // START PARENT CLASS TESTS

    [Fact]
    public void ShouldReportDefaultForNotSupportedViewModel()
    {
        this.CreateViewModel();
        Assert.False(this.shared.ViewModel.IsDefault);

        INotSupportedSetupViewModel defaultViewModel = new NotSupportedSetupViewModel(
            this.shared.MockConfigurationModel.Object,
            this.shared.MockStatsModel.Object,
            this.shared.MockMainModel.Object,
            Mock.Of<INotSupportedSetupModel>());

        Assert.True(defaultViewModel.IsDefault);
    }

    [Fact]
    public void ShouldMapDataConfigurationToModel()
    {
        this.CreateViewModel();
        this.shared.MockDataConfiguration.Setup(x => x.Name).Returns("MyName");
        Assert.Equal(
            this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name,
            this.shared.ViewModel.DataConfiguration.Name);
    }

    [Fact]
    public void ShouldPropagateDataTypeChangesToModels()
    {
        this.CreateViewModel();
        this.shared.ViewModel.SelectedDataType = this.GetValidImportExecutionKey();

        this.shared.MockConfigurationModel.VerifySet(
            x => x.ImportExecutionKey = this.shared.ViewModel.SelectedDataType,
            Times.Once);
        this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Once);
        Assert.Equal(
            this.shared.ViewModel.SelectedDataType.Name,
            this.shared.MockMainModel.Object.LoadedDataStructure.DataType);
    }

    [Fact]
    public void ShouldPropagateConfigNameChangesToModels()
    {
        const string expectedName = "MyConfigurationName";
        this.CreateViewModel();
        this.shared.ViewModel.ConfigurationName = expectedName;

        this.shared.MockConfigurationModel.VerifySet(x => x.ExecutiveConfigurationName = expectedName, Times.Once);
        this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Once);
        this.shared.MockCsvCSharpStringClassSetupModel.VerifyGet(x => x.DataConfiguration, Times.Exactly(2));
        Assert.Equal(expectedName, this.shared.MockMainModel.Object.LoadedDataStructure.StructureName);
        Assert.Equal(expectedName, this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name);
    }

    [Fact]
    public void ShouldPropagateConfigDirectoryChangesToModels()
    {
        const string expectedDir = "MyConfigDir";
        this.CreateViewModel();
        this.shared.ViewModel.ConfigurationDirectory = expectedDir;

        this.shared.MockConfigurationModel.VerifySet(x => x.ExecutiveConfigurationDirectory = expectedDir, Times.Once);
        this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Once);
        Assert.Equal(expectedDir, this.shared.MockMainModel.Object.LoadedDataStructure.DirectoryPath);
    }

    [Fact]
    public void ShouldPropagateExecutionTypeChangesToModels()
    {
        const string expectedDataType = "MyDataType";
        string expectedExecutionType = ExecutionType.CSharpStringProperties.ToString();
        string expectedConfigDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}" +
            $"\\DataAnalyzerConfigs\\{expectedExecutionType}\\{expectedDataType}_{expectedExecutionType}\\";
        this.CreateViewModel();

        Mock<ILoadedInputFiles> mockLoadedInputFiles = new();
        mockLoadedInputFiles.Setup(x => x.DataType).Returns(expectedDataType);
        this.shared.MockMainModel.Setup(x => x.LoadedInputFiles).Returns(mockLoadedInputFiles.Object);
        this.shared.MockMainModel.Setup(x => x.ApplyInputExecutionTypes()).Returns(true);

        this.shared.ViewModel.SelectedExecutionType = expectedExecutionType;

        Assert.Equal(expectedConfigDirectory, this.shared.ViewModel.ConfigurationDirectory);
        this.shared.MockConfigurationModel.VerifySet(x => x.SelectedExecutionType = ExecutionType.CSharpStringProperties, Times.Once);

        // The setter also sets the configuration directory which uses the LoadedDataStructure
        this.shared.MockMainModel.VerifyGet(x => x.LoadedDataStructure, Times.Exactly(2));
        Assert.Equal(expectedExecutionType, this.shared.MockMainModel.Object.LoadedDataStructure.ExecutionType);
    }

    [Fact]
    public void ShouldSetConfigDirectoryToNotSupportedIfUnableToApplyInputExecutionType()
    {
        const string expectedConfigDir = "NO SUPPORTED EXECUTIVE";
        this.CreateViewModel();
        this.shared.MockMainModel.Setup(x => x.ApplyInputExecutionTypes()).Returns(false);
        this.shared.ViewModel.SelectedExecutionType = ExecutionType.CSharpStringProperties.ToString();

        Assert.Equal(expectedConfigDir, this.shared.ViewModel.ConfigurationDirectory);
    }

    [Fact]
    public void ShouldMapCreatingNewDataConfigurationToModel()
    {
        this.CreateViewModel();
        this.shared.ViewModel.CreateNewDataConfiguration();
        this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.CreateNewDataConfiguration());
    }

    [Fact]
    public void ShouldMapLoadingConfigurationToModel()
    {
        const string expectedConfigName = "MyConfigName";
        this.CreateViewModel();
        this.shared.ViewModel.LoadConfiguration(expectedConfigName);
        this.shared.MockCsvCSharpStringClassSetupModel.Verify(x => x.LoadConfiguration(expectedConfigName));
    }

    //[Fact]
    //public void ShouldLoadViewModelFromConfigWhenDataConfigChanges()
    //{
    //    const string expectedConfigName = "MyName";
    //    const string expectedConfigClassName = "MyClassName";
    //    List<(string CsvName, string PropertyName, bool Include)> expectedNewValues = this.GetPropertyRowData();

    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.Name = expectedConfigName;
    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.ClassName = expectedConfigClassName;
    //    this.shared.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration.CsvNameAndProperties = expectedNewValues;

    //    this.CreateViewModel();
    //    this.shared.ViewModel.StartListeners();
    //    this.shared.ViewModel.CsvPropertyRows.Add(new StringPropertyRowViewModel() { SerializedName = "Bad", });

    //    this.shared.MockCsvCSharpStringClassSetupModel.Raise(
    //        this.shared.GetEventAction<IClassCreationSetupModel>(),
    //        this.shared.DataConfigChangeArgs);

    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows.Where(x => x.SerializedName.Equals("Bad")), 0);
    //    AssertionExtensions.CountIs(this.shared.ViewModel.CsvPropertyRows, 3);
    //    for (int i = 0; i < this.shared.ViewModel.CsvPropertyRows.Count; i++)
    //    {
    //        Assert.Equal(expectedNewValues[i].CsvName, this.shared.ViewModel.CsvPropertyRows[i].SerializedName);
    //        Assert.Equal(expectedNewValues[i].PropertyName, this.shared.ViewModel.CsvPropertyRows[i].PropertyName);
    //        Assert.Equal(expectedNewValues[i].Include, this.shared.ViewModel.CsvPropertyRows[i].Include);
    //    }
    //}

    [Fact]
    public void ShouldUpdateDataTypeWhenImportKeyChangesInModel()
    {
        IImportExecutionKey expectedKey = this.GetValidImportExecutionKey();
        this.CreateViewModel();
        this.shared.ViewModel.SelectedDataType = null;
        this.shared.ViewModel.StartListeners();

        this.shared.MockConfigurationModel.Setup(x => x.ImportExecutionKey).Returns(expectedKey);

        this.shared.MockConfigurationModel.Raise(
            this.shared.GetEventAction<IConfigurationModel>(),
            this.shared.ImportExecutionKeyChangeArgs);

        Assert.Equal(expectedKey, this.shared.ViewModel.SelectedDataType);
    }

    [Fact]
    public void ShouldUpdateExecutionTypeWhenExecutionTypeChangesInModel()
    {
        string expectedExecutionType = ExecutionType.CSharpStringProperties.ToString();
        this.CreateViewModel();
        this.shared.ViewModel.StartListeners();
        this.shared.ViewModel.SelectedExecutionType = ExecutionType.NotApplicable.ToString();

        this.shared.MockConfigurationModel.Setup(x => x.SelectedExecutionType).Returns(ExecutionType.CSharpStringProperties);

        this.shared.MockConfigurationModel.Raise(
            this.shared.GetEventAction<IConfigurationModel>(),
            this.shared.ExecutionTypeChangeArgs);

        Assert.Equal(expectedExecutionType, this.shared.ViewModel.SelectedExecutionType);
    }

    // END PARENT CLASS TESTS

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
            SerializedName = x.CsvName,
            PropertyName = x.PropertyName,
            Include = x.Include,
        })
        .Cast<IStringPropertyRowViewModel>()
        .ToList();

    private IImportExecutionKey GetValidImportExecutionKey() => new ImportExecutionKeyBuilder()
        .With(
            new FileImportType(),
            new CsvNamesScraperCategory(),
            new CsvTestScraperFlavor(),
            ExecutionType.CSharpStringProperties)
        .Build();

    private void CreateViewModel() =>
        this.shared.ViewModel = new(
            this.shared.MockConfigurationModel.Object,
            this.shared.MockMainModel.Object,
            this.shared.MockStatsModel.Object,
            this.shared.MockDefaultSetupViewModel.Object,
            this.shared.MockCsvCSharpStringClassSetupModel.Object);
}
