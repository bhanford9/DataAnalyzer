using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class EmptyParametersSerialization : SerializationAggregate<EmptyParameters>, IExcelActionParameterSerialization
  {
    public EmptyParametersSerialization() : base() { }

    public EmptyParametersSerialization(EmptyParameters value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
    }

    protected override ICollection<ISerializationData> InitializeSelf(EmptyParameters value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));

      return new List<ISerializationData>() { name };
    }
  }
}
