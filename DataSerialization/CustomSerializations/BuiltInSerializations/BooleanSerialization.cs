namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class BooleanSerialization : SerializationData<bool>
  {
    public BooleanSerialization() : base() { }

    public BooleanSerialization(bool value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = bool.Parse(valueAsString);
    }

    public override string ToString()
    {
      return this.DiscreteValue.ToString();
    }
  }
}
