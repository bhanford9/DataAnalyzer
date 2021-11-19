using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public abstract class TypeParameter : BasePropertyChanged, ITypeParameter
  {
    private ICellDataFormat cellDataFormat;
    private Func<ITypeParameter, ICellDataFormat> createCellDataFormat;

    public TypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
    {
      this.cellDataFormat = cellDataFormat;
      this.createCellDataFormat = createCellDataFormat;
    }

    public string Name => this.cellDataFormat.Name;

    public string Example => this.cellDataFormat.Example;

    public ICellDataFormat CreateCellDataFormat()
    {
      return this.createCellDataFormat(this);
    }
  }
}