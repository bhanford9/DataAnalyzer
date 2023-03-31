using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal class ExcelActionViewModel : BasePropertyChanged, IExcelActionViewModel
    {
        public ExcelActionViewModel(
            IActionCreationViewModel actionCreationViewModel,
            IActionApplicationViewModel actionApplicationViewModel,
            IActionsSummaryViewModel actionsSummaryViewModel)
        {
            this.ActionCreationViewModel = actionCreationViewModel;
            this.ActionApplicationViewModel = actionApplicationViewModel;
            this.ActionsSummaryViewModel = actionsSummaryViewModel;

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

        public IActionCreationViewModel ActionCreationViewModel { get; set; }

        public IActionApplicationViewModel ActionApplicationViewModel { get; set; }

        public IActionsSummaryViewModel ActionsSummaryViewModel { get; set; }
    }
}
