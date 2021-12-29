using System.Drawing;

namespace DataSerialization.CustomSerializations.BuiltInSerializations
{
  public class ColorSerialization : SerializationData<Color>
  {
    public ColorSerialization() : base() { }

    public ColorSerialization(Color value, string name) : base(value, name) { }

    public override void SetValueFromString(string valueAsString)
    {
      this.DiscreteValue = ColorParser.Parse(valueAsString);
    }

    public override string ToString()
    {
      return this.DiscreteValue.ToString();
    }
  }
}
