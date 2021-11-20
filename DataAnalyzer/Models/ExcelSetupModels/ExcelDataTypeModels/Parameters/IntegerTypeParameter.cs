using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerTypeParameter : TypeParameter
  {
    private int integerValue = 1;

    public IntegerTypeParameter(
      string integerName,
      ICellDataFormat cellDataFormat,
      Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
      this.IntegerName = integerName;
    }

    public int IntegerValue
    {
      get => this.integerValue;
      set
      {
        this.NotifyPropertyChanged(nameof(this.IntegerValue), ref this.integerValue, value);
        this.cellDataFormat = this.createCellDataFormat(this);
        this.NotifyPropertyChanged(nameof(this.Example));
      }
    }

    public string IntegerName { get; set; }

    public override ParameterType Type => ParameterType.Integer;
  }
}
