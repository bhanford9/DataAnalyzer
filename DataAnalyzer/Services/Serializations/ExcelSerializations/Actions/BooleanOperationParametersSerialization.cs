using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BooleanOperationParametersSerialization : SerializationAggregate<BooleanOperationParameters>, IExcelActionSerialization
  {
    public BooleanOperationParametersSerialization() : base() { }

    public BooleanOperationParametersSerialization(BooleanOperationParameters value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.DoPerform = this.GetParameter<bool>(nameof(this.DiscreteValue.DoPerform));
    }

    protected override ICollection<ISerializationData> InitializeSelf(BooleanOperationParameters value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      BooleanSerialization doPerform = new BooleanSerialization(value.DoPerform, nameof(value.DoPerform));

      return new List<ISerializationData>() { name, doPerform };
    }
  }
}
