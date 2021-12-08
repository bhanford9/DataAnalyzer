using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.Utilities;

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

    public override void FromSerializable(ISerializable serializable)
    {
      BooleanOperationParametersSerialization serialization = serializable as BooleanOperationParametersSerialization;
      this.Name = serialization.Name;
      this.DoPerform = serialization.DoPerform;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is BooleanOperationParametersSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new BooleanOperationParametersSerialization()
      {
        Name = this.Name,
        DoPerform = this.DoPerform
      };
    }
  }
}
