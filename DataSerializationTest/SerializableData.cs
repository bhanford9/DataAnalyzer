using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataSerializationTest
{
  public abstract class SerializableData : DefaultSerializable
  {
    public int Age { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public double HeightInches { get; set; } = 0.0;

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as SerializableData).Age,
        (obj, age) => (obj as SerializableData).Age = age,
        new IntegerSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as SerializableData).Name,
        (obj, name) => (obj as SerializableData).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        2,
        (obj) => (obj as SerializableData).HeightInches,
        (obj, height) => (obj as SerializableData).HeightInches = height,
        new DoubleSerializer());
    }
  }
}
