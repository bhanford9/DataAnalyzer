using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class BooleanOperationParametersSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public bool DoPerform { get; set; }

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as BooleanOperationParametersSerialization).Name,
        (obj, name) => (obj as BooleanOperationParametersSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as BooleanOperationParametersSerialization).DoPerform,
        (obj, color) => (obj as BooleanOperationParametersSerialization).DoPerform = color,
        new BoolSerializer());
    }
  }
}
