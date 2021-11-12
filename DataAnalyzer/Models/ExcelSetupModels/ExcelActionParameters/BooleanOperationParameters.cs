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
  }
}
