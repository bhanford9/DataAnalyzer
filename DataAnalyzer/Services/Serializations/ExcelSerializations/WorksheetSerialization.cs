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
      this.DiscreteValue.WorksheetActions = this.GetParameter<List<ExcelAction>>(nameof(this.DiscreteValue.WorksheetActions));
      this.DiscreteValue.DataClusters = this.GetParameter<List<DataClusterModel>>(nameof(this.DiscreteValue.DataClusters));
    }

    protected override ICollection<ISerializationData> InitializeSelf(WorksheetModel value)
    {
      StringSerialization name = new StringSerialization(value.WorksheetName, nameof(value.WorksheetName));
      SingleSerializationCollection<ExcelAction, ExcelActionSerialization> excelActions =
        new SingleSerializationCollection<ExcelAction, ExcelActionSerialization>(value.WorksheetActions, nameof(value.WorksheetActions));
      SingleSerializationCollection<DataClusterModel, DataClusterSerialization> dataClusters =
        new SingleSerializationCollection<DataClusterModel, DataClusterSerialization>(value.DataClusters, nameof(value.DataClusters));

      return new List<ISerializationData>() { name, excelActions, dataClusters };
    }
  }
}
