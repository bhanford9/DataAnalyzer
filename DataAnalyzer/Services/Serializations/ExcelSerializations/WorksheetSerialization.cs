using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class WorksheetSerialization : SerializationAggregate<WorksheetModel>
  {
    public WorksheetSerialization() : base()
    {
    }

    public WorksheetSerialization(WorksheetModel value, string parameterName) 
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.WorksheetName = this.GetParameter<string>(nameof(this.DiscreteValue.WorksheetName));
      this.DiscreteValue.WorksheetActions = this.GetParameter<ICollection<ExcelAction>>(nameof(this.DiscreteValue.WorksheetActions));
      this.DiscreteValue.DataClusters = this.GetParameter<ICollection<DataClusterModel>>(nameof(this.DiscreteValue.DataClusters));
    }

    protected override ICollection<ISerializationData> InitializeSelf(WorksheetModel value)
    {
      StringSerialization filePath = new StringSerialization(value.WorksheetName, nameof(value.WorksheetName));
      ExcelActionsSerialization excelActions = new ExcelActionsSerialization(value.WorksheetActions, nameof(value.WorksheetActions));

      return new List<ISerializationData>() { filePath, excelActions };
    }
  }
}
