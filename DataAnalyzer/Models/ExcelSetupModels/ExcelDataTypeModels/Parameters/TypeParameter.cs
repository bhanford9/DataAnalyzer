using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public abstract class TypeParameter : BasePropertyChanged, ITypeParameter
  {
    protected Func<ITypeParameter, ICellDataFormat> createCellDataFormat;
    protected ICellDataFormat cellDataFormat;

    public TypeParameter() : base() { }

    public TypeParameter(ITypeParameter other)
    {
      TypeParameter local = other as TypeParameter;
      this.createCellDataFormat = local.createCellDataFormat;
      this.cellDataFormat = local.cellDataFormat;
      this.Initialized = local.Initialized;
      this.DataName = local.DataName;
      this.CloneParameters(other);
    }

    public TypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
    {
      this.cellDataFormat = cellDataFormat;
      this.createCellDataFormat = createCellDataFormat;
      this.Initialized = true;
      this.NotifyPropertyChanged(nameof(this.Name));
    }

    public bool Initialized { get; } = false;

    public string Name => this.cellDataFormat.Name;

    public string Example => this.cellDataFormat.Example;

    public string DataName { get; set; } = string.Empty;

    public abstract ParameterType Type { get; }

    public abstract object[] GetParameterNameValuePairs();

    public ICellDataFormat CreateCellDataFormat()
    {
      return this.createCellDataFormat(this);
    }

    protected abstract void CloneParameters(ITypeParameter other);
  }
}