using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerBooleanTypeParameter : IntegerTypeParameter
  {
    private bool booleanValue = true;

    public IntegerBooleanTypeParameter() : base() { }

    public IntegerBooleanTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

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

    public override object[] GetParameterNameValuePairs()
    {
      return new object[]
      {
        this.IntegerName,
        this.IntegerValue,
        this.BooleanName,
        this.BooleanValue
      };
    }

    protected override void CloneParameters(ITypeParameter other)
    {
      IntegerBooleanTypeParameter local = other as IntegerBooleanTypeParameter;
      this.IntegerName = local.IntegerName;
      this.IntegerValue = local.IntegerValue;
      this.BooleanName = local.BooleanName;
      this.BooleanValue = local.BooleanValue;
    }
  }
}
