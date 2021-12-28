using DataSerialization.Utilities.BuiltInSerializers;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerIntegerTypeParameterSerialization : TypeParameterSerialization
  {
    public int Integer1Value { get; set; }

    public string Integer1Name { get; set; } = string.Empty;

    public int Integer2Value { get; set; }

    public string Integer2Name { get; set; } = string.Empty;
    public object BooleanName { get; internal set; }

    public override string DelimiterKey => "IntegerIntegerTypeParameter";

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.Integer1Name,
        this.Integer1Value,
        this.Integer2Name,
        this.Integer2Value
      };
    }

    protected override void InternalRegisterSerializations()
    {
      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as IntegerIntegerTypeParameterSerialization).Integer1Value,
        (obj, value) => (obj as IntegerIntegerTypeParameterSerialization).Integer1Value = value,
        new IntegerSerializer());

      this.RegisterSerializableParameter(
        5,
        (obj) => (obj as IntegerIntegerTypeParameterSerialization).Integer1Name,
        (obj, name) => (obj as IntegerIntegerTypeParameterSerialization).Integer1Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        6,
        (obj) => (obj as IntegerIntegerTypeParameterSerialization).Integer2Value,
        (obj, value) => (obj as IntegerIntegerTypeParameterSerialization).Integer2Value = value,
        new IntegerSerializer());

      this.RegisterSerializableParameter(
        7,
        (obj) => (obj as IntegerIntegerTypeParameterSerialization).Integer2Name,
        (obj, name) => (obj as IntegerIntegerTypeParameterSerialization).Integer2Name = name,
        new StringSerializer());
    }
  }
}
