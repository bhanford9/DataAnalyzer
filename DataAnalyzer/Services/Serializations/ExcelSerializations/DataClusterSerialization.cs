using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class DataClusterSerialization : SerializationAggregate<DataClusterModel>
  {
    public DataClusterSerialization() : base() { }

    public DataClusterSerialization(DataClusterModel value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Rows = this.GetParameter<ICollection<RowModel>>(nameof(this.DiscreteValue.Rows));
      this.DiscreteValue.TitleRow = this.GetParameter<RowModel>(nameof(this.DiscreteValue.TitleRow));
      this.DiscreteValue.DataClusterActions = this.GetParameter<ICollection<ExcelAction>>(nameof(this.DiscreteValue.DataClusterActions));
      this.DiscreteValue.StartRowIndex = this.GetParameter<int>(nameof(this.DiscreteValue.StartRowIndex));
      this.DiscreteValue.StartColIndex = this.GetParameter<int>(nameof(this.DiscreteValue.StartColIndex));
      this.DiscreteValue.UseClusterId = this.GetParameter<bool>(nameof(this.DiscreteValue.UseClusterId));
    }

    protected override ICollection<ISerializationData> InitializeSelf(DataClusterModel value)
    {
      SingleSerializationCollection<RowModel, RowSerialization> rows = 
        new SingleSerializationCollection<RowModel, RowSerialization>(value.Rows, nameof(value.Rows));
      RowSerialization titleRow = new RowSerialization(value.TitleRow, nameof(value.TitleRow));
      SingleSerializationCollection<ExcelAction, ExcelActionSerialization> excelActions =
        new SingleSerializationCollection<ExcelAction, ExcelActionSerialization>(value.DataClusterActions, nameof(value.DataClusterActions));
      IntegerSerialization startRow = new IntegerSerialization(value.StartRowIndex, nameof(value.StartRowIndex));
      IntegerSerialization startCol = new IntegerSerialization(value.StartColIndex, nameof(value.StartColIndex));
      BooleanSerialization useClusterId = new BooleanSerialization(value.UseClusterId, nameof(value.UseClusterId));

      return new List<ISerializationData>() { rows, titleRow, excelActions, startRow, startCol, useClusterId };
    }
  }
}
