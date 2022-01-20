using ExcelService.CellDataFormats;
using ExcelService.CellDataFormats.NumericFormat;
using ExcelService.DataActions.ActionParameters;
using ExcelService.Utilities;

namespace ExcelService.Cells
{
  public class Cell : ExcelEntity, ICell
  {
    public Cell(
      object value,
      int columnIndex,
      ICellDataFormat format = null,
      IActionDefinitions cellActions = null)
      : this(value, ColumnConversions.NumberToName(columnIndex + 1), format, cellActions)
    {
    }

    public Cell(
      object value,
      string columnId,
      ICellDataFormat format = null,
      IActionDefinitions cellActions = null)
    {
      this.Value = value;
      this.ColumnId = columnId;

      if (format != null)
      {
        this.Format = format;
      }

      if (cellActions != null)
      {
        this.ActionDefinitions = cellActions;
      }

      // may want to add IsValid method to ICellDataFormat interface
    }

    public override string Name => "Cell";

    public object Value { get; } = new object();

    public string ColumnId { get; } = string.Empty;

    public ICellDataFormat Format { get; } = new GeneralNumericCellDataFormat();

    public int StartRowNumber { get; set; } = 1;

    public int StartColNumber { get; set; } = 1;

    public int EndRowNumber => this.StartRowNumber;

    public int EndColNumber => this.StartColNumber;
  }
}
