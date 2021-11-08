using ExcelService.CellDataFormats;

namespace ExcelService.Cells
{
  public interface ICell : ICellRange
  {
    ICellDataFormat Format { get; }
    string ColumnId { get; }
    object Value { get; }
  }
}