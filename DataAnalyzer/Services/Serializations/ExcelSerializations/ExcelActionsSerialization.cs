using DataAnalyzer.Models.ExcelSetupModels;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class ExcelActionsSerialization : SingleSerializationCollection<ExcelAction, ExcelActionSerialization>
  {
    public ExcelActionsSerialization() : base() { }

    public ExcelActionsSerialization(ExcelActionSerialization serialization)
      : base(serialization)
    {
    }

    public ExcelActionsSerialization(ICollection<ExcelAction> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }
  }
}
