using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class IntegerIntegerTypeParameterSerialization : SerializationAggregate<IntegerIntegerTypeParameter>
  {
    public IntegerIntegerTypeParameterSerialization() : base() { }

    public IntegerIntegerTypeParameterSerialization(IntegerIntegerTypeParameter value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      string name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      this.DiscreteValue = excelDataTypeLibrary.GetByName(name) as IntegerIntegerTypeParameter;
      this.DiscreteValue.Integer1Name = this.GetParameter<string>(nameof(this.DiscreteValue.Integer1Name));
      this.DiscreteValue.Integer1Value = this.GetParameter<int>(nameof(this.DiscreteValue.Integer1Value));
      this.DiscreteValue.Integer2Name = this.GetParameter<string>(nameof(this.DiscreteValue.Integer2Name));
      this.DiscreteValue.Integer2Value = this.GetParameter<int>(nameof(this.DiscreteValue.Integer2Value));
      this.DiscreteValue.DataName = this.GetParameter<string>(nameof(this.DiscreteValue.DataName));
    }

    protected override ICollection<ISerializationData> InitializeSelf(IntegerIntegerTypeParameter value)
    {
      StringSerialization name = new StringSerialization(value.Initialized ? value.Name : string.Empty, nameof(value.Name));
      StringSerialization integer1Name = new StringSerialization(value.Integer1Name, nameof(value.Integer1Name));
      IntegerSerialization integer1Value = new IntegerSerialization(value.Integer1Value, nameof(value.Integer1Value));
      StringSerialization integer2Name = new StringSerialization(value.Integer2Name, nameof(value.Integer2Name));
      IntegerSerialization integer2Value = new IntegerSerialization(value.Integer2Value, nameof(value.Integer2Value));
      StringSerialization dataName = new StringSerialization(value.DataName, nameof(value.DataName));

      return new List<ISerializationData>() { name, integer1Name, integer1Value, integer2Name, integer2Value, dataName };
    }
  }
}
