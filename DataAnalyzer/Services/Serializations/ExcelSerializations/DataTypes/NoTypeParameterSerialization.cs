using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class NoTypeParameterSerialization : SerializationAggregate<NoTypeParameter>
  {
    public NoTypeParameterSerialization() : base() { }

    public NoTypeParameterSerialization(NoTypeParameter value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      string name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      this.DiscreteValue = excelDataTypeLibrary.GetByName(name) as NoTypeParameter;
      this.DiscreteValue.DataName = this.GetParameter<string>(nameof(this.DiscreteValue.DataName));
    }

    protected override ICollection<ISerializationData> InitializeSelf(NoTypeParameter value)
    {
      if (!value.Initialized)
      {
        return new List<ISerializationData>();
      }

      StringSerialization name = new StringSerialization(value.Initialized ? value.Name : string.Empty, nameof(value.Name));
      StringSerialization dataName = new StringSerialization(value.DataName, nameof(value.DataName));
      return new List<ISerializationData>() { name, dataName };
    }
  }
}
