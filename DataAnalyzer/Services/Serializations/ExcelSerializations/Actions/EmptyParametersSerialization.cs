using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class EmptyParametersSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public override string DelimiterKey => "EmptyParameters";

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as EmptyParametersSerialization).Name,
        (obj, name) => (obj as EmptyParametersSerialization).Name = name,
        new StringSerializer());
    }
  }
}
