using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAnalyzer.ViewModels.Utilities
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
