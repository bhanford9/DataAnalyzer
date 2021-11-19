using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerIntegerTypeParameter : TypeParameter
  {
    public IntegerIntegerTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public int Integer1Value { get; set; }

    public int Integer2Value { get; set; }
  }
}
