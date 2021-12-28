using DataSerialization.Utilities.BuiltInSerializers;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerBooleanTypeParameterSerialization : TypeParameterSerialization
  {
    public string IntegerName { get; set; } = string.Empty;

    public int IntegerValue { get; set; }

    public string BooleanName { get; set; } = string.Empty;

    public bool BooleanValue { get; set; }

    public override string DelimiterKey => "IntegerBooleanTypeParameter";

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.IntegerName,
        this.IntegerValue,
        this.BooleanName,
        this.BooleanValue
      };
    }

    protected override void InternalRegisterSerializations()
    {
      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as IntegerBooleanTypeParameterSerialization).IntegerValue,
        (obj, value) => (obj as IntegerBooleanTypeParameterSerialization).IntegerValue = value,
        new IntegerSerializer());

      this.RegisterSerializableParameter(
        5,
        (obj) => (obj as IntegerBooleanTypeParameterSerialization).IntegerName,
        (obj, name) => (obj as IntegerBooleanTypeParameterSerialization).IntegerName = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        6,
        (obj) => (obj as IntegerBooleanTypeParameterSerialization).BooleanValue,
        (obj, value) => (obj as IntegerBooleanTypeParameterSerialization).BooleanValue = value,
        new BoolSerializer());

      this.RegisterSerializableParameter(
        7,
        (obj) => (obj as IntegerBooleanTypeParameterSerialization).BooleanName,
        (obj, name) => (obj as IntegerBooleanTypeParameterSerialization).BooleanName = name,
        new StringSerializer());
    }
  }
}
