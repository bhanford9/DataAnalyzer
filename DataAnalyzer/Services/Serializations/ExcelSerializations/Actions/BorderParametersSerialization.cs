using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;
using System.Drawing;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BorderParametersSerialization : SerializationAggregate<BorderParameters>, IExcelActionParameterSerialization
  {
    public BorderParametersSerialization() : base() { }

    public BorderParametersSerialization(BorderParameters value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.LeftColor = this.GetParameter<Color>(nameof(this.DiscreteValue.LeftColor));
      this.DiscreteValue.TopColor = this.GetParameter<Color>(nameof(this.DiscreteValue.TopColor));
      this.DiscreteValue.RightColor = this.GetParameter<Color>(nameof(this.DiscreteValue.RightColor));
      this.DiscreteValue.BottomColor = this.GetParameter<Color>(nameof(this.DiscreteValue.BottomColor));
      this.DiscreteValue.AllColor = this.GetParameter<Color>(nameof(this.DiscreteValue.AllColor));
      this.DiscreteValue.DiagonalUpColor = this.GetParameter<Color>(nameof(this.DiscreteValue.DiagonalUpColor));
      this.DiscreteValue.DiagonalDownColor = this.GetParameter<Color>(nameof(this.DiscreteValue.DiagonalDownColor));

      this.DiscreteValue.LeftStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.LeftStyle));
      this.DiscreteValue.TopStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.TopStyle));
      this.DiscreteValue.RightStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.RightStyle));
      this.DiscreteValue.BottomStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.BottomStyle));
      this.DiscreteValue.AllStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.AllStyle));
      this.DiscreteValue.DiagonalUpStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.DiagonalUpStyle));
      this.DiscreteValue.DiagonalDownStyle = this.GetParameter<BorderStyle>(nameof(this.DiscreteValue.DiagonalDownStyle));

      this.DiscreteValue.Nth = this.GetParameter<int>(nameof(this.DiscreteValue.Nth));
    }

    protected override ICollection<ISerializationData> InitializeSelf(BorderParameters value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));

      ColorSerialization leftColor = new ColorSerialization(value.LeftColor, nameof(value.LeftColor));
      ColorSerialization topColor = new ColorSerialization(value.TopColor, nameof(value.TopColor));
      ColorSerialization rightColor = new ColorSerialization(value.RightColor, nameof(value.RightColor));
      ColorSerialization bottomColor = new ColorSerialization(value.BottomColor, nameof(value.BottomColor));
      ColorSerialization allColor = new ColorSerialization(value.AllColor, nameof(value.AllColor));
      ColorSerialization diagonalUpColor = new ColorSerialization(value.DiagonalUpColor, nameof(value.DiagonalUpColor));
      ColorSerialization diagonalDownColor = new ColorSerialization(value.DiagonalDownColor, nameof(value.DiagonalDownColor));

      EnumSerialization<BorderStyle> leftStyle = new EnumSerialization<BorderStyle>(value.LeftStyle, nameof(value.LeftStyle));
      EnumSerialization<BorderStyle> topStyle = new EnumSerialization<BorderStyle>(value.TopStyle, nameof(value.TopStyle));
      EnumSerialization<BorderStyle> rightStyle = new EnumSerialization<BorderStyle>(value.RightStyle, nameof(value.RightStyle));
      EnumSerialization<BorderStyle> bottomStyle = new EnumSerialization<BorderStyle>(value.BottomStyle, nameof(value.BottomStyle));
      EnumSerialization<BorderStyle> allStyle = new EnumSerialization<BorderStyle>(value.AllStyle, nameof(value.AllStyle));
      EnumSerialization<BorderStyle> diagonalUpStyle = new EnumSerialization<BorderStyle>(value.DiagonalUpStyle, nameof(value.DiagonalUpStyle));
      EnumSerialization<BorderStyle> diagonalDownStyle = new EnumSerialization<BorderStyle>(value.DiagonalDownStyle, nameof(value.DiagonalDownStyle));

      IntegerSerialization nth = new IntegerSerialization(value.Nth, nameof(value.Nth));

      return new List<ISerializationData>()
      {
        name,
        leftColor,
        topColor,
        rightColor,
        bottomColor,
        allColor,
        diagonalUpColor,
        diagonalDownColor,
        leftStyle,
        topStyle,
        rightStyle,
        bottomStyle,
        allStyle,
        diagonalUpStyle,
        diagonalDownStyle,
        nth
      };
    }
  }
}
