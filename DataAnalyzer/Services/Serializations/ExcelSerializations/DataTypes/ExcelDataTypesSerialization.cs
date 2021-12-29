using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class ExcelDataTypesSerialization : SerializationCollection<ITypeParameter>
  {
    public ExcelDataTypesSerialization() : base() { }

    public ExcelDataTypesSerialization(ICollection<ITypeParameter> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(IntegerBooleanTypeParameter), new IntegerBooleanTypeParameterSerialization());
      this.RegisterType(typeof(IntegerIntegerTypeParameter), new IntegerIntegerTypeParameterSerialization());
      this.RegisterType(typeof(IntegerTypeParameter), new IntegerTypeParameterSerialization());
      this.RegisterType(typeof(NoTypeParameter), new NoTypeParameterSerialization());
    }
  }
}
