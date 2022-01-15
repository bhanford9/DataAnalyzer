using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class CellSerialization : SerializationAggregate<CellModel>
  {
    public CellSerialization() : base() { }

    public CellSerialization(CellModel value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.CellActions = this.GetParameter<List<ExcelAction>>(nameof(this.DiscreteValue.CellActions));
      this.DiscreteValue.Value = this.GetParameter<object>(nameof(this.DiscreteValue.Value));
    }

    protected override ICollection<ISerializationData> InitializeSelf(CellModel value)
    {
      StringSerialization cellValue = new StringSerialization(value.Value.ToString(), nameof(value.Value));
      SingleSerializationCollection<ExcelAction, ExcelActionSerialization> excelActions = 
        new SingleSerializationCollection<ExcelAction, ExcelActionSerialization>(value.CellActions, nameof(value.CellActions));

      return new List<ISerializationData>() { cellValue, excelActions };
    }
  }
}
