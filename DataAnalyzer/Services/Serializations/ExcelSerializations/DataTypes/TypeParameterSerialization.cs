using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public abstract class TypeParameterSerialization : DefaultSerializable
  {
    public string Name { get; set; } = string.Empty;

    public string DataName { get; set; } = string.Empty;

    public string Example { get; set; } = string.Empty;

    public ParameterType Type { get; set; }

    public abstract object[] GetParameterNameValuePairs();

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as TypeParameterSerialization).Name,
        (obj, name) => (obj as TypeParameterSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as TypeParameterSerialization).Example,
        (obj, example) => (obj as TypeParameterSerialization).Example = example,
        new StringSerializer());

      this.RegisterSerializableParameter(
        2,
        (obj) => (obj as TypeParameterSerialization).Type,
        (obj, type) => (obj as TypeParameterSerialization).Type = type,
        (content) => Enum.Parse<ParameterType>(content));

      this.RegisterSerializableParameter(
        3,
        (obj) => (obj as TypeParameterSerialization).DataName,
        (obj, dataName) => (obj as TypeParameterSerialization).DataName = dataName,
        new StringSerializer());

      this.InternalRegisterSerializations();
    }

    protected abstract void InternalRegisterSerializations();
  }
}
