using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.Utilities;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class NoTypeParameter : TypeParameter
  {
    public NoTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public override ParameterType Type => ParameterType.None;

    public override void FromSerializable(ISerializable serializable)
    {
      // TODO --> this should be the base of all From Serializable Type Parameters and then
      //   an abstract internal one should be done for the extra parameters
      NoTypeParameterSerialization serialization = serializable as NoTypeParameterSerialization;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      NoTypeParameter typeParameter = excelDataTypeLibrary.GetByName(serialization.Name) as NoTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is NoTypeParameterSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new NoTypeParameterSerialization()
      {
        DataName = this.DataName,
        Example = this.Example,
        Name = this.Name,
        Type = this.Type
      };
    }
  }
}
