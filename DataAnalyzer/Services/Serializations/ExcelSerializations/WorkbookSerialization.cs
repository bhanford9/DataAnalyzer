using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class WorkbookSerialization : SerializationAggregate<WorkbookModel>
  {
    public WorkbookSerialization() : base() { }

    public WorkbookSerialization(WorkbookModel value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.FilePath = this.GetParameter<string>(nameof(this.DiscreteValue.FilePath));
      this.DiscreteValue.WorkbookActions = this.GetParameter<ICollection<ExcelAction>>(nameof(this.DiscreteValue.WorkbookActions));
      this.DiscreteValue.Worksheets = this.GetParameter<ICollection<WorksheetModel>>(nameof(this.DiscreteValue.Worksheets));
    }

    protected override ICollection<ISerializationData> InitializeSelf(WorkbookModel value)
    {
      StringSerialization filePath = new StringSerialization(value.FilePath, nameof(value.FilePath));
      ExcelActionsSerialization excelActions = new ExcelActionsSerialization(value.WorkbookActions, nameof(value.WorkbookActions));
      WorksheetsSerialization worksheets = new WorksheetsSerialization(value.Worksheets, nameof(value.Worksheets));

      return new List<ISerializationData>() { filePath, excelActions, worksheets };
    }
  }
}
