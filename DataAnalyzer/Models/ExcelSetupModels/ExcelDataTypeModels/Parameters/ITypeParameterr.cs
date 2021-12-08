using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public interface ITypeParameter : ISerializablePropertyChanged
  {
    string Name { get; }
    string Example { get; }
    ParameterType Type { get; }
    string DataName { get; set; }

    ICellDataFormat CreateCellDataFormat();
  }
}
