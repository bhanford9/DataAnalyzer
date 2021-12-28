using DataSerialization.Utilities.BuiltInSerializers;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerTypeParameterSerialization : TypeParameterSerialization
  {
    public string IntegerName { get; set; } = string.Empty;

    public int IntegerValue { get; set; }

    public override string DelimiterKey => "SingleIntegerTypeParameter";

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.IntegerName,
        this.IntegerValue
      };
    }

    protected override void InternalRegisterSerializations()
    {
      this.RegisterSerializableParameter(
        4,
        (obj) => (obj as IntegerTypeParameterSerialization).IntegerValue,
        (obj, value) => (obj as IntegerTypeParameterSerialization).IntegerValue = value,
        new IntegerSerializer());

      this.RegisterSerializableParameter(
        5,
        (obj) => (obj as IntegerTypeParameterSerialization).IntegerName,
        (obj, name) => (obj as IntegerTypeParameterSerialization).IntegerName = name,
        new StringSerializer());
    }
  }
}
