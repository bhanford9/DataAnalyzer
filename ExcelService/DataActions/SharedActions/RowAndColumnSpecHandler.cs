using ClosedXML.Excel;
using ExcelService.Utilities;

namespace ExcelService.DataActions.SharedActions;

internal static class RowAndColumnSpecHandler
{
    public static void Handle(ColumnRowSpecification spec, IXLRange range, Action<IXLRangeBase> act)
    {
        if (spec.ColumnSpecification.AllColumns && spec.RowSpecification.AllRows)
        {
            act(range);
        }
        else if (spec.ColumnSpecification.AllColumns)
        {
            act(range.Row(spec.RowSpecification.NthRow));
        }
        else if (spec.RowSpecification.AllRows)
        {
            if (spec.ColumnSpecification.UseNthColumn)
            {
                act(range.Column(spec.ColumnSpecification.NthColumn));
            }
            else if (spec.ColumnSpecification.UseColumnAddress)
            {
                act(range.Column(spec.ColumnSpecification.ColumnAddress));
            }
            else if (spec.ColumnSpecification.UseColumnHeader)
            {
                // not currently possible with parameters passed in
                act(range.Column(spec.ColumnSpecification.ColumnHeader));
            }
        }
        else
        {
            IXLRangeColumn? column = default;

            if (spec.ColumnSpecification.UseNthColumn)
            {
                column = range.Column(spec.ColumnSpecification.NthColumn);
            }
            else if (spec.ColumnSpecification.UseColumnAddress)
            {
                column = range.Column(spec.ColumnSpecification.ColumnAddress);
            }
            else if (spec.ColumnSpecification.UseColumnHeader)
            {
                // not currently possible with parameters passed in
                column = range.Column(spec.ColumnSpecification.ColumnHeader);
            }

            act(column!.Cell(spec.RowSpecification.NthRow).CurrentRegion);
        }
    }
}
