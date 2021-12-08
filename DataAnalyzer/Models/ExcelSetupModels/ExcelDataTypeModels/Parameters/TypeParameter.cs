using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public abstract class TypeParameter : SerializablePropertyChanged, ITypeParameter
  {
    protected Func<ITypeParameter, ICellDataFormat> createCellDataFormat;
    protected ICellDataFormat cellDataFormat;

    public TypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
    {
      this.cellDataFormat = cellDataFormat;
      this.createCellDataFormat = createCellDataFormat;
      this.NotifyPropertyChanged(nameof(this.Name));
    }

    public string Name => this.cellDataFormat.Name;

    public string Example => this.cellDataFormat.Example;

    public string DataName { get; set; } = string.Empty;

    public abstract ParameterType Type { get; }

    public ICellDataFormat CreateCellDataFormat()
    {
      return this.createCellDataFormat(this);
    }
  }
}