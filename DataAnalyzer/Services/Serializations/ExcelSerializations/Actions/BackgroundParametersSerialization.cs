using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;
using System.Drawing;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BackgroundParametersSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public Color BackgroundColor { get; set; }

    public Color PatternColor { get; set; }

    public FillPattern FillPattern { get; set; }

    public int Nth { get; set; } = -1;

    public override string DelimiterKey => "BackgroundParameters";

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as BackgroundParametersSerialization).Name,
        (obj, name) => (obj as BackgroundParametersSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as BackgroundParametersSerialization).BackgroundColor,
        (obj, color) => (obj as BackgroundParametersSerialization).BackgroundColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        2,
        (obj) => (obj as BackgroundParametersSerialization).PatternColor,
        (obj, color) => (obj as BackgroundParametersSerialization).PatternColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        3,
        (obj) => (obj as BackgroundParametersSerialization).FillPattern,
        (obj, style) => (obj as BackgroundParametersSerialization).FillPattern = style,
        Enum.Parse<FillPattern>);

      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as BackgroundParametersSerialization).Nth,
        (obj, nth) => (obj as BackgroundParametersSerialization).Nth = nth,
        new IntegerSerializer());
    }
  }
}
