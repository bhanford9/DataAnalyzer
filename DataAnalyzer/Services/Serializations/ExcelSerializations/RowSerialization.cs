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
      CellsSerialization cells = new CellsSerialization(value.Cells, nameof(value.Cells));
      ExcelActionsSerialization excelActions = new ExcelActionsSerialization(value.RowActions, nameof(value.RowActions));

      return new List<ISerializationData>() { cells, excelActions };
    }
  }
}
