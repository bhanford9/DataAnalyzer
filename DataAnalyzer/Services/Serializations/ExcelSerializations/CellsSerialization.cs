using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class CellsSerialization : SingleSerializationCollection<CellModel, CellSerialization>
  {
    public CellsSerialization() : base() { }

    public CellsSerialization(CellSerialization serialization)
      : base(serialization)
    {
    }

    public CellsSerialization(ICollection<CellModel> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }
  }
}
