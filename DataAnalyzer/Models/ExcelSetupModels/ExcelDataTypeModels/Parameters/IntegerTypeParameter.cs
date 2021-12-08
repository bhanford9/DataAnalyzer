using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.Utilities;
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

    public override void FromSerializable(ISerializable serializable)
    {
      IntegerTypeParameterSerialization serialization = serializable as IntegerTypeParameterSerialization;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      IntegerTypeParameter typeParameter = excelDataTypeLibrary.GetByName(serialization.Name) as IntegerTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
      this.IntegerName = serialization.IntegerName;
      this.IntegerValue = serialization.IntegerValue;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is IntegerTypeParameterSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new IntegerTypeParameterSerialization()
      {
        DataName = this.DataName,
        Example = this.Example,
        IntegerName = this.IntegerName,
        IntegerValue = this.IntegerValue,
        Name = this.Name,
        Type = this.Type
      };
    }
  }
}
