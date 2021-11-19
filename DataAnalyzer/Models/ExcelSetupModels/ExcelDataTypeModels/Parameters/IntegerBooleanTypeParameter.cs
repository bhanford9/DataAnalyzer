using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerBooleanTypeParameter : IntegerTypeParameter
  {
    public IntegerBooleanTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public bool BooleanValue { get; set; }
  }
}
