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
      this.DiscreteValue.ActionParameters = this.GetParameter<IActionParameters>(this.DiscreteValue.Name);
      this.DiscreteValue.ActionParameterType = this.GetParameter<string>(nameof(this.DiscreteValue.ActionParameterType));
    }

    protected override ICollection<ISerializationData> InitializeSelf(ExcelAction value)
    {
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      StringSerialization description = new StringSerialization(value.Description, nameof(value.Description));
      BooleanSerialization isBuiltIn = new BooleanSerialization(value.IsBuiltIn, nameof(value.IsBuiltIn));

      StringSerialization actionTypeSerialization = new StringSerialization(value.ActionParameterType, nameof(value.ActionParameterType));

      List<ISerializationData> items = new List<ISerializationData>() { name, description, isBuiltIn, actionTypeSerialization };

      if (value.ActionParameters != null)
      {
        IExcelActionParameterSerialization excelActionSerialization =
          new ExcelActionParametersSerialization().GetSerializationData(value.ActionParameters.GetType()) as IExcelActionParameterSerialization;
        excelActionSerialization.Initialize(value.ActionParameters.Name, value.ActionParameters);
        items.Add(excelActionSerialization);
      }

      return items;
    }
  }
}
