using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzerFixtures.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzerTest.Utilities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ExcelParams = DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzerTest.ViewModels.Unit.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;

public class ActionApplicationViewModelTests : IClassFixture<ActionApplicationViewModelFixture>
{
    private readonly ActionApplicationViewModelFixture shared;

    public ActionApplicationViewModelTests(ActionApplicationViewModelFixture sharedData)
    {
        this.shared = sharedData;

        this.shared.MockStatsModel = new();
        this.shared.MockActionApplicationModel = new();
        this.shared.MockExcelEntitySpecification = new();
        this.shared.MockEmptyEditViewModel = new();

        this.shared.MockEditActionLibrary = new();
        this.shared.MockEditActionLibrary
            .Setup(x => x.GetEditAction(
                It.IsAny<IEmptyParameters>(),
                It.IsAny<IExcelEntitySpecification>()))
            .Returns(this.shared.MockEmptyEditViewModel.Object);
    }

    [Fact]
    public void ShouldInitializeActions()
    {
        this.CreateViewModel(this.GetActionList());
        AssertionExtensions.CountIs(this.shared.ViewModel.Actions, 3);
    }

    [Fact]
    public void ShouldRecursivelyApplyAction()
    {
        const int expectedApplied = 3;

        this.CreateViewModel(this.GetActionList());
        this.LoadNestedWhereToApply();

        this.shared.ViewModel.ApplyAction.Execute(null);

        this.shared.MockEmptyEditViewModel.Verify(
            x => x.ApplyParameterSettings(),
            Times.Exactly(expectedApplied));

        this.shared.MockActionApplicationModel.Verify(
            x => x.ApplyAction(
                It.IsAny<ICheckableTreeViewItem>(),
                this.shared.MockEmptyEditViewModel.Object),
            Times.Exactly(expectedApplied));
    }

    [Fact]
    public void ShouldLoadFromStatsWhenHeirarchalStatsChange()
    {
        this.CreateViewModel(this.GetActionList());
        this.LoadNestedWhereToApply();

        this.shared.MockStatsModel.Raise(
            this.shared.GetEventAction<IStatsModel>(),
            this.shared.HeirarchalStatsChangeArgs);

        Assert.Equal("All Workbooks", this.shared.ViewModel.WhereToApply.First().Name);
        Assert.Equal("", this.shared.ViewModel.WhereToApply.First().Path);

        this.shared.MockActionApplicationModel.Verify(
            x => x.LoadWhereToApply(this.shared.ViewModel.WhereToApply.First()),
            Times.Once);
    }

    [Fact]
    public void ShouldSetupCurrentActionWhenLoadedActionNameChanges()
    {
        const string expectedName = "MyName";
        const string expectedDescription = "MyDescription";

        this.CreateViewModel(this.GetActionList());

        Mock<ExcelParams.IActionParameters> mockExpectedActionParameters = new();

        Mock<IExcelAction> mockExcelAction = new();
        mockExcelAction.Setup(x => x.ActionParameters).Returns(mockExpectedActionParameters.Object);
        mockExcelAction.Setup(x => x.Name).Returns(expectedName);
        mockExcelAction.Setup(x => x.Description).Returns(expectedDescription);

        Mock<IEditActionViewModel> mockEditActionViewModel = new();

        this.shared.MockActionApplicationModel
            .Setup(x => x.GetLoadedAction())
            .Returns(mockExcelAction.Object);

        this.shared.MockEditActionLibrary
            .Setup(x => x.GetEditAction(
                mockExcelAction.Object.ActionParameters,
                this.shared.ViewModel.ExcelEntityType))
            .Returns(mockEditActionViewModel.Object);

        this.shared.MockActionApplicationModel.Raise(
            this.shared.GetEventAction<IActionApplicationModel>(),
            this.shared.LoadedActionNameChangeArgs);

        this.shared.MockActionApplicationModel.Verify(x => x.GetLoadedAction(), Times.Once);
        this.shared.MockEditActionLibrary.Verify(
            x => x.GetEditAction(
                mockExcelAction.Object.ActionParameters,
                this.shared.ViewModel.ExcelEntityType),
            Times.Once);
        mockEditActionViewModel.VerifySet(x => x.ActionName = expectedName);
        mockEditActionViewModel.VerifySet(x => x.Description = expectedDescription);
        mockEditActionViewModel.VerifySet(x => x.ActionParameters = mockExpectedActionParameters.Object);
    }

    private void LoadNestedWhereToApply()
    {
        this.shared.ViewModel.WhereToApply.Add(GetTreeViewItem("Name1"));
        this.shared.ViewModel.WhereToApply.First().Children.Add(GetTreeViewItem("Name2", isChecked: false));
        this.shared.ViewModel.WhereToApply.First().Children.First().Children.Add(GetTreeViewItem("Name3"));
        this.shared.ViewModel.WhereToApply.First().Children.Add(GetTreeViewItem("Name4", isLeaf: false));
        this.shared.ViewModel.WhereToApply.First().Children.Add(GetTreeViewItem("Name5"));
    }

    private ICollection<IExcelAction> GetActionList() => new List<IExcelAction>()
    {
        Mock.Of<IExcelAction>(),
        Mock.Of<IExcelAction>(),
        Mock.Of<IExcelAction>(),
    };

    private ICheckableTreeViewItem GetTreeViewItem(
        string name,
        bool isChecked = true,
        bool isLeaf = true) =>
        new CheckableTreeViewItem()
        {
            IsChecked = isChecked,
            IsLeaf = isLeaf,
            Name = name,
        };

    private void CreateViewModel(ICollection<IExcelAction> actions = null)
    {
        this.shared.ViewModel = new ActionApplicationViewModel(
            this.shared.MockStatsModel.Object,
            this.shared.MockEditActionLibrary.Object,
            actions ?? new List<IExcelAction>(),
            this.shared.MockActionApplicationModel.Object,
            this.shared.MockExcelEntitySpecification.Object);
    }
}
