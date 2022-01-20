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
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.WorkbookActions = this.GetParameter<List<ExcelAction>>(nameof(this.DiscreteValue.WorkbookActions));
      this.DiscreteValue.Worksheets = this.GetParameter<List<WorksheetModel>>(nameof(this.DiscreteValue.Worksheets));
    }

    protected override ICollection<ISerializationData> InitializeSelf(WorkbookModel value)
    {
      StringSerialization filePath = new StringSerialization(value.FilePath, nameof(value.FilePath));
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      SingleSerializationCollection<ExcelAction, ExcelActionSerialization> excelActions =
        new SingleSerializationCollection<ExcelAction, ExcelActionSerialization>(value.WorkbookActions, nameof(value.WorkbookActions));
      SingleSerializationCollection<WorksheetModel, WorksheetSerialization> worksheets =
        new SingleSerializationCollection<WorksheetModel, WorksheetSerialization>(value.Worksheets, nameof(value.Worksheets));

      return new List<ISerializationData>() { filePath, name, excelActions, worksheets };
    }
  }
}
