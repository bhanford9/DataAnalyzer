using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ExcelActionViewModel : BasePropertyChanged
  {
    private readonly IActionCreationModel actionCreationModel;
    private readonly IActionApplicationModel actionApplicationModel;

    public ExcelActionViewModel(
      ICollection<ExcelAction> actions,
      IActionCreationModel actionCreationModel,
      IActionApplicationModel actionApplicationModel)
    {
      this.actionCreationModel = actionCreationModel;
      this.actionApplicationModel = actionApplicationModel;

      this.ActionCreationViewModel = new ActionCreationViewModel(
        actions,
        actionCreationModel);

      this.ActionApplicationViewModel = new ActionApplicationViewModel(
        actions,
        actionApplicationModel);
    }

    public ActionCreationViewModel ActionCreationViewModel { get; set; }

    public ActionApplicationViewModel ActionApplicationViewModel { get; set; }
  }
}
