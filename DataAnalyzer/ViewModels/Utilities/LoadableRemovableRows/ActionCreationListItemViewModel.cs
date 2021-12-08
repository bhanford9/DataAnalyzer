using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
  public class ActionCreationListItemViewModel : LoadableRemovableRowViewModel
  {
    private readonly IActionCreationModel actionCreationModel;

    public ActionCreationListItemViewModel(IActionCreationModel model)
    {
      this.actionCreationModel = model;
    }

    protected override void DoLoad()
    {
      // could be built in or custom
      this.actionCreationModel.LoadAction(this.Value);
    }

    protected override void InternalDoRemove()
    {
      // TODO --> Prompt user with "Are you sure?"
      throw new NotImplementedException();
    }
  }
}
