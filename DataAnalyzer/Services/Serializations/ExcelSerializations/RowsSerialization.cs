using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class RowsSerialization : SingleSerializationCollection<RowModel, RowSerialization>
  {
    public RowsSerialization() : base() { }

    public RowsSerialization(RowSerialization serialization)
      : base(serialization)
    {
    }

    public RowsSerialization(ICollection<RowModel> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }
  }
}
