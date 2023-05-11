namespace ExcelService.Utilities;

// TODO --> keep connecting up the column row specs with all of the excel actions
// Excel side data structures should be only that, no causation during setting of params
// Each action should behave similar to that of AlignmentAction
// Need to test all connections from V --> VM --> M --> Excel (and back up)
public class ColumnSpecification : IColumnSpecification
{
    public int NthColumn { get; set; }

    public string ColumnAddress { get; set; } = string.Empty;

    public string ColumnHeader { get; set; } = string.Empty;

    public bool AllColumns { get; set; } = true;

    public bool UseNthColumn { get; set; } = false;

    public bool UseColumnAddress { get; set; } = false;

    public bool UseColumnHeader { get; set; } = false;
}
