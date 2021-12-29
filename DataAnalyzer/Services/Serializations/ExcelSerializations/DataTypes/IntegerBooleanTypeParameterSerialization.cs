using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerBooleanTypeParameterSerialization : SerializationAggregate<IntegerBooleanTypeParameter>
  {
    public IntegerBooleanTypeParameterSerialization() : base() { }

    public IntegerBooleanTypeParameterSerialization(IntegerBooleanTypeParameter value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      string name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      this.DiscreteValue = excelDataTypeLibrary.GetByName(name) as IntegerBooleanTypeParameter;
      this.DiscreteValue.IntegerName = this.GetParameter<string>(nameof(this.DiscreteValue.IntegerName));
      this.DiscreteValue.IntegerValue = this.GetParameter<int>(nameof(this.DiscreteValue.IntegerValue));
      this.DiscreteValue.BooleanName = this.GetParameter<string>(nameof(this.DiscreteValue.BooleanName));
      this.DiscreteValue.BooleanValue = this.GetParameter<bool>(nameof(this.DiscreteValue.BooleanValue));
      this.DiscreteValue.DataName = this.GetParameter<string>(nameof(this.DiscreteValue.DataName));
    }

    protected override ICollection<ISerializationData> InitializeSelf(IntegerBooleanTypeParameter value)
    {
      StringSerialization name = new StringSerialization(value.Initialized ? value.Name : string.Empty, nameof(value.Name));
      StringSerialization integerName = new StringSerialization(value.IntegerName, nameof(value.IntegerName));
      IntegerSerialization integerValue = new IntegerSerialization(value.IntegerValue, nameof(value.IntegerValue));
      StringSerialization booleanName = new StringSerialization(value.BooleanName, nameof(value.BooleanName));
      BooleanSerialization booleanValue = new BooleanSerialization(value.BooleanValue, nameof(value.BooleanValue));
      StringSerialization dataName = new StringSerialization(value.DataName, nameof(value.DataName));

      return new List<ISerializationData>() { name, integerName, integerValue, booleanName, booleanValue, dataName };
    }
  }
}
