using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;
using System.Drawing;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BackgroundParametersSerialization : SerializationAggregate<BackgroundParameters>, IExcelActionParameterSerialization
  {
    public BackgroundParametersSerialization() : base() { }

    public BackgroundParametersSerialization(BackgroundParameters value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.BackgroundColor = this.GetParameter<Color>(nameof(this.DiscreteValue.BackgroundColor));
      this.DiscreteValue.PatternColor = this.GetParameter<Color>(nameof(this.DiscreteValue.PatternColor));
      this.DiscreteValue.FillPattern = this.GetParameter<FillPattern>(nameof(this.DiscreteValue.FillPattern));
      this.DiscreteValue.Nth = this.GetParameter<int>(nameof(this.DiscreteValue.Nth));
    }

    protected override ICollection<ISerializationData> InitializeSelf(BackgroundParameters value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      ColorSerialization backgroundColor = new ColorSerialization(value.BackgroundColor, nameof(value.BackgroundColor));
      ColorSerialization patternColor = new ColorSerialization(value.PatternColor, nameof(value.PatternColor));
      EnumSerialization<FillPattern> fillPattern = new EnumSerialization<FillPattern>(value.FillPattern, nameof(value.FillPattern));
      IntegerSerialization nth = new IntegerSerialization(value.Nth, nameof(value.Nth));

      return new List<ISerializationData>() { name, backgroundColor, patternColor, fillPattern, nth };
    }
  }
}
