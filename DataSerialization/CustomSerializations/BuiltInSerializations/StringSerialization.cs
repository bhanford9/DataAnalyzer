namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class StringSerialization : SerializationData<string>
  {
    public StringSerialization() : base() { }

    public StringSerialization(string value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = valueAsString;
    }

    public override string ToString()
    {
      return this.DiscreteValue?.ToString();
    }
  }
}
