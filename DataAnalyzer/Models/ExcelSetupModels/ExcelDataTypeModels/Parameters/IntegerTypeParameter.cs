using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerTypeParameter : TypeParameter
  {
    public IntegerTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public int IntegerValue { get; set; }
  }
}
