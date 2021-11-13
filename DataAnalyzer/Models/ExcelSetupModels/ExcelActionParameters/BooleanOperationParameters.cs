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

    public override string SerializedParameters => this.Serialize(this.doPerform);

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter);

      this.DoPerform = bool.Parse(parameters[0]);
    }
  }
}
