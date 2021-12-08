using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.Utilities;
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

    public override void FromSerializable(ISerializable serializable)
    {
      IntegerBooleanTypeParameterSerialization serialization = serializable as IntegerBooleanTypeParameterSerialization;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      IntegerBooleanTypeParameter typeParameter = excelDataTypeLibrary.GetByName(serialization.Name) as IntegerBooleanTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
      this.IntegerName = serialization.IntegerName;
      this.IntegerValue = serialization.IntegerValue;
      this.BooleanName = serialization.BooleanName;
      this.BooleanValue = serialization.BooleanValue;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is IntegerBooleanTypeParameterSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new IntegerBooleanTypeParameterSerialization()
      {
        DataName = this.DataName,
        Example = this.Example,
        IntegerName = this.IntegerName,
        IntegerValue = this.IntegerValue,
        BooleanName = this.BooleanName,
        BooleanValue = this.BooleanValue,
        Name = this.Name,
        Type = this.Type
      };
    }
  }
}
