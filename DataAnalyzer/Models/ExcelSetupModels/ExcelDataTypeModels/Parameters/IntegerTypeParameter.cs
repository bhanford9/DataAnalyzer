using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.CustomSerializations;
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

    public override void FromSerializable(ISerializationData serializable)
    {
      IntegerTypeParameter parameters = (serializable as IntegerTypeParameterSerialization).DiscreteValue;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      IntegerTypeParameter typeParameter = excelDataTypeLibrary.GetByName(parameters.Name) as IntegerTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
      this.IntegerName = parameters.IntegerName;
      this.IntegerValue = parameters.IntegerValue;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is IntegerTypeParameterSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new IntegerTypeParameterSerialization();
    }

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
