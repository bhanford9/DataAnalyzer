using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerTypeParameterSerialization : SerializationAggregate<IntegerTypeParameter>
  {
    public IntegerTypeParameterSerialization() : base() { }

    public IntegerTypeParameterSerialization(IntegerTypeParameter value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      string name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      this.DiscreteValue = excelDataTypeLibrary.GetByName(name) as IntegerTypeParameter;
      this.DiscreteValue.IntegerName = this.GetParameter<string>(nameof(this.DiscreteValue.IntegerName));
      this.DiscreteValue.IntegerValue = this.GetParameter<int>(nameof(this.DiscreteValue.IntegerValue));
      this.DiscreteValue.DataName = this.GetParameter<string>(nameof(this.DiscreteValue.DataName));
    }

    protected override ICollection<ISerializationData> InitializeSelf(IntegerTypeParameter value)
    {
      StringSerialization name = new StringSerialization(value.Initialized ? value.Name : string.Empty, nameof(value.Name));
      StringSerialization integerName = new StringSerialization(value.IntegerName, nameof(value.IntegerName));
      IntegerSerialization integerValue = new IntegerSerialization(value.IntegerValue, nameof(value.IntegerValue));
      StringSerialization dataName = new StringSerialization(value.DataName, nameof(value.DataName));

      return new List<ISerializationData>() { name, integerName, integerValue, dataName };
    }
  }
}
