using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class BooleanActionViewModel : EditActionViewModel
  {
    private bool doPerform = false;

    public BooleanActionViewModel()
    {
    }

    public BooleanActionViewModel(IActionCreationModel actionCreationModel, IEditActionViewModel toCopy)
      : base(actionCreationModel, toCopy)
    {
    }

    public bool DoPerform
    {
      get => this.doPerform;
      set => this.NotifyPropertyChanged(nameof(this.DoPerform), ref this.doPerform, value);
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      BooleanActionViewModel viewModel = new BooleanActionViewModel(this.actionCreationModel, this);
      BooleanOperationParameters booleanParameters = parameters as BooleanOperationParameters;
      viewModel.DoPerform = booleanParameters.DoPerform;
      return viewModel;
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return parameters is BooleanOperationParameters;
    }

    protected override void DoAct()
    {
      throw new NotImplementedException();
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
    }
  }
}
