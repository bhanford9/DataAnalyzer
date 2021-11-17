using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class EmptyEditViewModel : EditActionViewModel
  {
    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      return new EmptyEditViewModel();
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return parameters is EmptyParameters;
    }

    protected override void DoAct()
    {
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
    }
  }
}
