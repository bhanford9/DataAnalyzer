using System;

namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class EnumSerialization<T> : SerializationData<T>
    where T : struct
  {
    public EnumSerialization() : base() { }

    public EnumSerialization(T value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = Enum.Parse<T>(valueAsString);
    }

    public override string ToString()
    {
      return this.DiscreteValue.ToString();
    }
  }
}
