using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public abstract class TypeParameter : BasePropertyChanged, ITypeParameter
  {
    protected readonly Func<ITypeParameter, ICellDataFormat> createCellDataFormat;
    protected ICellDataFormat cellDataFormat;

    public TypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
    {
      this.cellDataFormat = cellDataFormat;
      this.createCellDataFormat = createCellDataFormat;
    }

    public string Name => this.cellDataFormat.Name;

    public string Example => this.cellDataFormat.Example;

    public abstract ParameterType Type { get; }

    public ICellDataFormat CreateCellDataFormat()
    {
      return this.createCellDataFormat(this);
    }
  }
}