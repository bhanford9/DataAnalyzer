using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.CustomSerializations;

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

    public override void FromSerializable(ISerializationData serializable)
    {
      BooleanOperationParameters parameters = (serializable as BooleanOperationParametersSerialization).DiscreteValue;
      this.Name = parameters.Name;
      this.DoPerform = parameters.DoPerform;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is BooleanOperationParametersSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new BooleanOperationParametersSerialization();
    }
  }
}
