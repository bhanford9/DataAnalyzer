using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
  public class ExcelActionViewModel : BasePropertyChanged
  {
    private readonly IActionCreationModel actionCreationModel;

    public ExcelActionViewModel(
      ICollection<ExcelAction> actions,
      IActionCreationModel actionCreationModel)
    {
      this.actionCreationModel = actionCreationModel;

      this.ActionCreationViewModel = new ActionCreationViewModel(
        actions,
        actionCreationModel);
    }

    public ActionCreationViewModel ActionCreationViewModel { get; set; }
  }
}
