namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class IntegerSerialization : SerializationData<int>
  {
    public IntegerSerialization() : base() { }

    public IntegerSerialization(int value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = int.Parse(valueAsString);
    }

    public override string ToString()
    {
      return this.DiscreteValue.ToString();
    }
  }
}
