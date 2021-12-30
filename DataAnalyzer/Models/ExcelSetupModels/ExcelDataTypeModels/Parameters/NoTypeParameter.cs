using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class NoTypeParameter : TypeParameter
  {
    public NoTypeParameter() : base() { }

    public NoTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

    public NoTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public override ParameterType Type => ParameterType.None;

    public override object[] GetParameterNameValuePairs()
    {
      return new object[] { };
    }

    protected override void CloneParameters(ITypeParameter other)
    {
    }
  }
}
