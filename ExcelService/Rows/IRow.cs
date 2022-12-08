using ExcelService.Cells;
using System.Collections.Generic;

namespace ExcelService.Rows
{
    public interface IRow : IList<ICell>, ICellRange
    {
    }
}
