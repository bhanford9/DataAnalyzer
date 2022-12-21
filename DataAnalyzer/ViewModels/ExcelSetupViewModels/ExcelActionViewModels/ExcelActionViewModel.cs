using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Services;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal class ExcelActionViewModel : BasePropertyChanged
    {
        public ExcelActionViewModel(
          ICollection<ExcelAction> actions,
          IActionCreationModel actionCreationModel,
          IActionApplicationModel actionApplicationModel,
          IActionsSummaryModel actionsSummaryModel,
          ExcelEntityType type)
        {
            this.ActionCreationViewModel = new ActionCreationViewModel(
              actions,
              actionCreationModel,
              type);

            this.ActionApplicationViewModel = new ActionApplicationViewModel(
              actions,
              actionApplicationModel,
              type);

            this.ActionsSummaryViewModel = new ActionsSummaryViewModel(
              actionsSummaryModel,
              type);
        }

        public ActionCreationViewModel ActionCreationViewModel { get; set; }

        public ActionApplicationViewModel ActionApplicationViewModel { get; set; }

        public ActionsSummaryViewModel ActionsSummaryViewModel { get; set; }
    }
}
