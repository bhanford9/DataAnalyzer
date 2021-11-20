using ExcelService.CellDataFormats;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public interface ITypeParameter : INotifyPropertyChanged
  {
    string Name { get; }
    string Example { get; }
    ParameterType Type { get; }

    ICellDataFormat CreateCellDataFormat();
  }
}
