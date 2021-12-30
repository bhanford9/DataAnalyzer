using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerTypeParameter : TypeParameter
  {
    private int integerValue = 1;

    public IntegerTypeParameter() : base() { }

    public IntegerTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

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

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.IntegerName,
        this.IntegerValue
      };
    }

    protected override void CloneParameters(ITypeParameter other)
    {
      IntegerTypeParameter local = other as IntegerTypeParameter;
      this.IntegerName = local.IntegerName;
      this.IntegerValue = local.IntegerValue;
    }
  }
}
