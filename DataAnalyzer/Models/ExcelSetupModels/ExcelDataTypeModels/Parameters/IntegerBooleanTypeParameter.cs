using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerBooleanTypeParameter : IntegerTypeParameter
  {
    private bool booleanValue = true;

    public IntegerBooleanTypeParameter(
      string integerName,
      string booleanName,
      ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(integerName, cellDataFormat, createCellDataFormat)
    {
      this.BooleanName = booleanName;
    }

    public bool BooleanValue
    {
      get => this.booleanValue;
      set
      {
        this.NotifyPropertyChanged(nameof(this.BooleanValue), ref this.booleanValue, value);
        this.cellDataFormat = this.createCellDataFormat(this);
        this.NotifyPropertyChanged(nameof(this.Example));
      }
    }

    public string BooleanName { get; set; }

    public override ParameterType Type => ParameterType.IntegerBoolean;
  }
}
