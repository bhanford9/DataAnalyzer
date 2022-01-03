using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class BooleanOperationParameters : ActionParameters
  {
    private bool doPerform = false;

    public bool DoPerform
    {
      get => this.doPerform;
      set => this.NotifyPropertyChanged(nameof(this.DoPerform), ref this.doPerform, value);
    }

    public override ActionCategory ActionCategory => ActionCategory.BooleanOperation;

    public override string ToString()
    {
      return $"Do Perform: {this.DoPerform}{Environment.NewLine}";
    }
  }
}
