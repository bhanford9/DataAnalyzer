using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class AlignmentParametersSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public VerticalAlignment VerticalAlignment { get; set; }

    public int Nth { get; set; } = -1;

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as AlignmentParametersSerialization).Name,
        (obj, name) => (obj as AlignmentParametersSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        3,
        (obj) => (obj as AlignmentParametersSerialization).HorizontalAlignment,
        (obj, style) => (obj as AlignmentParametersSerialization).HorizontalAlignment = style,
        Enum.Parse<HorizontalAlignment>);

      this.RegisterSerializableParameter(
        3,
        (obj) => (obj as AlignmentParametersSerialization).VerticalAlignment,
        (obj, style) => (obj as AlignmentParametersSerialization).VerticalAlignment = style,
        Enum.Parse<VerticalAlignment>);

      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as AlignmentParametersSerialization).Nth,
        (obj, nth) => (obj as AlignmentParametersSerialization).Nth = nth,
        new IntegerSerializer());
    }
  }
}
