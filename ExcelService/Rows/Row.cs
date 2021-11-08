using ExcelService.Cells;
using ExcelService.DataActions.ActionParameters;
using System.Collections.Generic;

namespace ExcelService.Rows
{
  public class Row : List<ICell>, IRow
  {
    public Row(
      ICollection<ICell> cells,
      IActionDefinitions rowActions = null)
    {
      this.AddRange(cells);

      if (rowActions != null)
      {
        this.ActionDefinitions = rowActions;
      }
    }

    public IActionDefinitions ActionDefinitions { get; protected set; } = new ActionDefinitions();

    public int StartRowNumber { get; set; } = 1;

    public int StartColNumber { get; set; } = 1;

    public int EndRowNumber => this.StartRowNumber;

    public int EndColNumber => this.StartColNumber + this.Count - 1;

    public string Name => "Row";
  }
}