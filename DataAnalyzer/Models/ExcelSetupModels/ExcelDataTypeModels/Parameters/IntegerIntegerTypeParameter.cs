using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerIntegerTypeParameter : TypeParameter
  {
    private int integer1Value = 1;
    private int integer2Value = 1;

    public IntegerIntegerTypeParameter() : base() { }

    public IntegerIntegerTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

    public IntegerIntegerTypeParameter(
      string integer1Name,
      string integer2Name,
      ICellDataFormat cellDataFormat, 
      Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
      this.Integer1Name = integer1Name;
      this.Integer2Name = integer2Name;
    }

    public int Integer1Value
    {
      get => this.integer1Value;
      set
      {
        this.NotifyPropertyChanged(nameof(this.Integer1Value), ref this.integer1Value, value);
        this.cellDataFormat = this.createCellDataFormat(this);
        this.NotifyPropertyChanged(nameof(this.Example));
      }
    }

    public int Integer2Value
    {
      get => this.integer2Value;
      set
      {
        this.NotifyPropertyChanged(nameof(this.Integer2Value), ref this.integer2Value, value);
        this.cellDataFormat = this.createCellDataFormat(this);
        this.NotifyPropertyChanged(nameof(this.Example));
      }
    }

    public string Integer1Name { get; set; }

    public string Integer2Name { get; set; }

    public override ParameterType Type => ParameterType.IntegerInteger;

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.Integer1Name,
        this.Integer1Value,
        this.Integer2Name,
        this.Integer2Value
      };
    }

    protected override void CloneParameters(ITypeParameter other)
    {
      IntegerIntegerTypeParameter local = other as IntegerIntegerTypeParameter;
      this.Integer1Name = local.Integer1Name;
      this.Integer1Value = local.Integer1Value;
    }
  }
}
