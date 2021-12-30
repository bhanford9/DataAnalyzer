using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class WorksheetsSerialization : SingleSerializationCollection<WorksheetModel, WorksheetSerialization>
  {
    public WorksheetsSerialization() : base() { }

    public WorksheetsSerialization(WorksheetSerialization serialization)
      : base(serialization)
    {
    }

    public WorksheetsSerialization(ICollection<WorksheetModel> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }
  }
}
