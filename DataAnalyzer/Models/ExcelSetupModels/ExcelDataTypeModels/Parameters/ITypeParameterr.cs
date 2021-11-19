using ExcelService.CellDataFormats;
namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
  public interface ITypeParameter
  {
    string Name { get; }
    string Example { get; }

    ICellDataFormat CreateCellDataFormat();
  }
}
