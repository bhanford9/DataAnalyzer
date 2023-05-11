using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels;

internal class ExcelActionViewModel : BasePropertyChanged, IExcelActionViewModel
{
    // TODO --> create sub classes for each of the 3 action view model types per spec type
    //   all they do is pass in the respective spec type to the base class
    public ExcelActionViewModel(
        IActionCreationViewModel actionCreationViewModel,
        IActionApplicationViewModel actionApplicationViewModel,
        IActionsSummaryViewModel actionsSummaryViewModel,
        IExcelEntitySpecification excelEntitySpecification)
    {
        ActionCreationViewModel = actionCreationViewModel;
        ActionApplicationViewModel = actionApplicationViewModel;
        ActionsSummaryViewModel = actionsSummaryViewModel;
        Specification = excelEntitySpecification;

        // TODO --> all of these can be injected instead
        //this.ActionCreationViewModel = new ActionCreationViewModel(
        //    actions,
        //    actionCreationModel,
        //    type);

        //this.ActionApplicationViewModel = new ActionApplicationViewModel(
        //    statsModel,
        //    actions,
        //    actionApplicationModel,
        //    type);

        //this.ActionsSummaryViewModel = new ActionsSummaryViewModel(
        //    statsModel,
        //    structureExecutiveCommissioner,
        //    actionsSummaryModel,
        //    type);
    }

    public IActionCreationViewModel ActionCreationViewModel { get; }

    public IActionApplicationViewModel ActionApplicationViewModel { get; }

    public IActionsSummaryViewModel ActionsSummaryViewModel { get; }

    public IExcelEntitySpecification Specification { get; }
}
