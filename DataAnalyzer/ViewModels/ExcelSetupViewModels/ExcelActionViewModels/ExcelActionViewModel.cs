using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ExcelActionViewModel : BasePropertyChanged
  {
    public ExcelActionViewModel(
      ICollection<ExcelAction> actions,
      IActionCreationModel actionCreationModel,
      IActionApplicationModel actionApplicationModel,
      IActionsSummaryModel actionsSummaryModel)
    {
      this.ActionCreationViewModel = new ActionCreationViewModel(
        actions,
        actionCreationModel);

      this.ActionApplicationViewModel = new ActionApplicationViewModel(
        actions,
        actionApplicationModel);

      this.ActionsSummaryViewModel = new ActionsSummaryViewModel(
        actionsSummaryModel);
    }

    public ActionCreationViewModel ActionCreationViewModel { get; set; }

    public ActionApplicationViewModel ActionApplicationViewModel { get; set; }

    public ActionsSummaryViewModel ActionsSummaryViewModel { get; set; }
  }
}
