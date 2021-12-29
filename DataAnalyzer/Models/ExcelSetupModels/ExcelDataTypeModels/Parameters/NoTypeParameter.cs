using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;
using DataSerialization.CustomSerializations;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public class NoTypeParameter : TypeParameter
  {
    public NoTypeParameter() : base() { }

    public NoTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

    public NoTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
      : base(cellDataFormat, createCellDataFormat)
    {
    }

    public override ParameterType Type => ParameterType.None;

    public override void FromSerializable(ISerializationData serializable)
    {
      NoTypeParameter parameters = (serializable as NoTypeParameterSerialization).DiscreteValue;
      ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
      NoTypeParameter typeParameter = excelDataTypeLibrary.GetByName(parameters.Name) as NoTypeParameter;
      this.cellDataFormat = typeParameter.cellDataFormat;
      this.createCellDataFormat = typeParameter.createCellDataFormat;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is NoTypeParameterSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new NoTypeParameterSerialization();
    }

    public override object[] GetParameterNameValuePairs()
    {
      return new object[] { };
    }

    protected override void CloneParameters(ITypeParameter other)
    {
    }
  }
}
