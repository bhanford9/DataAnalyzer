using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
  public class WorkbookConfigListItemViewModel : LoadableRemovableRowViewModel
  {
    private readonly ExcelConfigurationModel excelConfigurationModel = BaseSingleton<ExcelConfigurationModel>.Instance;

    protected override void DoLoad()
    {
      this.excelConfigurationModel.LoadWorkbookConfigByName(this.Value);
    }

    protected override void InternalDoRemove()
    {
      // TODO --> prompt user with confirmation
      throw new NotImplementedException();
    }
  }
}
