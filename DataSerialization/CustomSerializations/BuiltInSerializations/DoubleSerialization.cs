namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class DoubleSerialization : SerializationData<double>
  {
    public DoubleSerialization() : base() { }

    public DoubleSerialization(double value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = double.Parse(valueAsString);
    }

    public override string ToString()
    {
      return this.DiscreteValue.ToString();
    }
  }
}
