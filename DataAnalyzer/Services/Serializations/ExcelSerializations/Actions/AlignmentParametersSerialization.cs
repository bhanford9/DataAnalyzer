using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class AlignmentParametersSerialization : SerializationAggregate<AlignmentParameters>
  {
    public string Name { get; set; } = string.Empty;

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public VerticalAlignment VerticalAlignment { get; set; }

    public int Nth { get; set; } = -1;

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
      CustomSerialization<HorizontalAlignment> horizontal = new CustomSerialization<HorizontalAlignment>(
        value.HorizontalAlignment,
        nameof(value.HorizontalAlignment),
        (alignment) => alignment.ToString(),
        (str) => Enum.Parse<HorizontalAlignment>(str));
      CustomSerialization<VerticalAlignment> vertical = new CustomSerialization<VerticalAlignment>(
        value.VerticalAlignment,
        nameof(value.HorizontalAlignment),
        (alignment) => alignment.ToString(),
        (str) => Enum.Parse<VerticalAlignment>(str));
      IntegerSerialization nth = new IntegerSerialization(value.Nth, nameof(value.Nth));

      return new List<ISerializationData>() { name, horizontal, vertical, nth };
    }
  }
}
