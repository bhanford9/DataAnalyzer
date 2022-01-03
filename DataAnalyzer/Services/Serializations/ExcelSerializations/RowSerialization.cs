using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class RowSerialization : SerializationAggregate<RowModel>
  {
    public RowSerialization() : base() { }

    public RowSerialization(RowModel value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.RowActions = this.GetParameter<ICollection<ExcelAction>>(nameof(this.DiscreteValue.RowActions));
      this.DiscreteValue.Cells = this.GetParameter<ICollection<CellModel>>(nameof(this.DiscreteValue.Cells));
    }

    protected override ICollection<ISerializationData> InitializeSelf(RowModel value)
    {
      SingleSerializationCollection<CellModel, CellSerialization> cells =
        new SingleSerializationCollection<CellModel, CellSerialization>(value.Cells, nameof(value.Cells));
      SingleSerializationCollection<ExcelAction, ExcelActionSerialization> excelActions = 
        new SingleSerializationCollection<ExcelAction, ExcelActionSerialization>(value.RowActions, nameof(value.RowActions));

      return new List<ISerializationData>() { cells, excelActions };
    }
  }
}
