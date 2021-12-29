using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class AlignmentParametersSerialization : SerializationAggregate<AlignmentParameters>, IExcelActionSerialization
  {
    public AlignmentParametersSerialization() : base() { }

    public AlignmentParametersSerialization(AlignmentParameters value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.HorizontalAlignment = this.GetParameter<HorizontalAlignment>(nameof(this.DiscreteValue.HorizontalAlignment));
      this.DiscreteValue.VerticalAlignment = this.GetParameter<VerticalAlignment>(nameof(this.DiscreteValue.VerticalAlignment));
      this.DiscreteValue.Nth = this.GetParameter<int>(nameof(this.DiscreteValue.Nth));
    }

    protected override ICollection<ISerializationData> InitializeSelf(AlignmentParameters value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      EnumSerialization<HorizontalAlignment> horizontal = 
        new EnumSerialization<HorizontalAlignment>(value.HorizontalAlignment, nameof(value.HorizontalAlignment));
      EnumSerialization<VerticalAlignment> vertical =
        new EnumSerialization<VerticalAlignment>(value.VerticalAlignment, nameof(value.VerticalAlignment));
      IntegerSerialization nth = new IntegerSerialization(value.Nth, nameof(value.Nth));

      return new List<ISerializationData>() { name, horizontal, vertical, nth };
    }
  }
}
