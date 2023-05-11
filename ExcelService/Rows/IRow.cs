using ExcelService.Cells;

namespace ExcelService.Rows;

public interface IRow : IList<ICell>, ICellRange
{
}
