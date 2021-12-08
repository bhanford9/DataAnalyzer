using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.Utilities;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class IntegerIntegerTypeParameter : TypeParameter
  {
    private int integer1Value = 1;
    private int integer2Value = 1;

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

    public override void FromSerializable(ISerializable serializable)
    {
      IntegerIntegerTypeParameterSerialization serialization = serializable as IntegerIntegerTypeParameterSerialization;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      IntegerIntegerTypeParameter typeParameter = excelDataTypeLibrary.GetByName(serialization.Name) as IntegerIntegerTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
      this.Integer1Name = serialization.Integer1Name;
      this.Integer1Value = serialization.Integer1Value;
      this.Integer2Name = serialization.Integer2Name;
      this.Integer2Value = serialization.Integer2Value;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is IntegerIntegerTypeParameterSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new IntegerIntegerTypeParameterSerialization()
      {
        DataName = this.DataName,
        Example = this.Example,
        Integer1Name = this.Integer1Name,
        Integer1Value = this.Integer1Value,
        Integer2Name = this.Integer2Name,
        Integer2Value = this.Integer2Value,
        Name = this.Name,
        Type = this.Type
      };
    }
  }
}
