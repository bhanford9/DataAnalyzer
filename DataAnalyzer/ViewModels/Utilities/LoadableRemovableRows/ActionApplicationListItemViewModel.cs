using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
  public class ActionApplicationListItemViewModel : LoadableRemovableRowViewModel
  {
    private readonly IActionApplicationModel actionApplicationModel;

    public ActionApplicationListItemViewModel(IActionApplicationModel model)
    {
      this.actionApplicationModel = model;
    }

    protected override void DoLoad()
    {
      this.actionApplicationModel.LoadAction(this.Value);
    }

    protected override void InternalDoRemove()
    {
      // Not Applicable
    }
  }
}
