using System;

namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class CustomSerialization<T> : SerializationData<T>
  {

    public CustomSerialization() : base() { }

    public CustomSerialization(
      T value,
      string name,
      Func<T, string> serialize,
      Func<string, T> deserialize) : base (value, name)
    {
      this.Serialize = serialize;
      this.Deserialize = deserialize;
    }

    public Func<string, T> Deserialize { get; set; }

    public Func<T, string> Serialize { get; set; }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = this.Deserialize(valueAsString);
    }

    public override string ToString()
    {
      return this.Serialize(this.DiscreteValue);
    }
  }
}
