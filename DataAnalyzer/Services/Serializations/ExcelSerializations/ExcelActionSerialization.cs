using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class ExcelActionSerialization : SerializationAggregate<ExcelAction>
  {
    public ExcelActionSerialization() : base() { }

    public ExcelActionSerialization(ExcelAction value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.Description = this.GetParameter<string>(nameof(this.DiscreteValue.Description));
      this.DiscreteValue.IsBuiltIn = this.GetParameter<bool>(nameof(this.DiscreteValue.IsBuiltIn));
      this.DiscreteValue.ActionParameters = this.GetParameter<IActionParameters>(nameof(this.DiscreteValue.ActionParameters));
    }

    protected override ICollection<ISerializationData> InitializeSelf(ExcelAction value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      StringSerialization description = new StringSerialization(value.Description, nameof(value.Description));
      BooleanSerialization isBuiltIn = new BooleanSerialization(value.IsBuiltIn, nameof(value.IsBuiltIn));
      IExcelActionParameterSerialization excelActionSerialization = (IExcelActionParameterSerialization)Activator.CreateInstance(
        value.ActionParameters.GetType(),
        value.ActionParameters,
        nameof(value.ActionParameters));

      return new List<ISerializationData>() { name, description, isBuiltIn, excelActionSerialization };
    }
  }
}
