using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;
using System.Drawing;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BorderParametersSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public Color LeftColor { get; set; }
    public Color TopColor { get; set; }
    public Color RightColor { get; set; }
    public Color BottomColor { get; set; }
    public Color AllColor { get; set; }
    public Color DiagonalUpColor { get; set; }
    public Color DiagonalDownColor { get; set; }

    public BorderStyle LeftStyle { get; set; }
    public BorderStyle TopStyle { get; set; }
    public BorderStyle RightStyle { get; set; }
    public BorderStyle BottomStyle { get; set; }
    public BorderStyle AllStyle { get; set; }
    public BorderStyle DiagonalUpStyle { get; set; }
    public BorderStyle DiagonalDownStyle { get; set; }

    public int Nth { get; set; } = -1;

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as BorderParametersSerialization).Name,
        (obj, name) => (obj as BorderParametersSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as BorderParametersSerialization).LeftColor,
        (obj, color) => (obj as BorderParametersSerialization).LeftColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        2,
        (obj) => (obj as BorderParametersSerialization).TopColor,
        (obj, color) => (obj as BorderParametersSerialization).TopColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        3,
        (obj) => (obj as BorderParametersSerialization).RightColor,
        (obj, color) => (obj as BorderParametersSerialization).RightColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as BorderParametersSerialization).BottomColor,
        (obj, color) => (obj as BorderParametersSerialization).BottomColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        5,
        (obj) => (obj as BorderParametersSerialization).AllColor,
        (obj, color) => (obj as BorderParametersSerialization).AllColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        6,
        (obj) => (obj as BorderParametersSerialization).DiagonalUpColor,
        (obj, color) => (obj as BorderParametersSerialization).DiagonalUpColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        7,
        (obj) => (obj as BorderParametersSerialization).DiagonalDownColor,
        (obj, color) => (obj as BorderParametersSerialization).DiagonalDownColor = color,
        ColorParser.Parse);

      this.RegisterSerializableParameter(
        8,
        (obj) => (obj as BorderParametersSerialization).LeftStyle,
        (obj, style) => (obj as BorderParametersSerialization).LeftStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        9,
        (obj) => (obj as BorderParametersSerialization).TopStyle,
        (obj, style) => (obj as BorderParametersSerialization).TopStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        10,
        (obj) => (obj as BorderParametersSerialization).RightStyle,
        (obj, style) => (obj as BorderParametersSerialization).RightStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        11,
        (obj) => (obj as BorderParametersSerialization).BottomStyle,
        (obj, style) => (obj as BorderParametersSerialization).BottomStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        12,
        (obj) => (obj as BorderParametersSerialization).AllStyle,
        (obj, style) => (obj as BorderParametersSerialization).AllStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        13,
        (obj) => (obj as BorderParametersSerialization).DiagonalUpStyle,
        (obj, style) => (obj as BorderParametersSerialization).DiagonalUpStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        14,
        (obj) => (obj as BorderParametersSerialization).DiagonalDownStyle,
        (obj, style) => (obj as BorderParametersSerialization).DiagonalDownStyle = style,
        Enum.Parse<BorderStyle>);

      this.RegisterSerializableParameter(
        15,
        (obj) => (obj as BorderParametersSerialization).Nth,
        (obj, nth) => (obj as BorderParametersSerialization).Nth = nth,
        new IntegerSerializer());
    }
  }
}
