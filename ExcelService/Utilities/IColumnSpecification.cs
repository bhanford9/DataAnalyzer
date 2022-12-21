namespace ExcelService.Utilities
{
    public interface IColumnSpecification
    {
        string ColumnAddress { get; set; }
        string ColumnHeader { get; set; }
        int NthColumn { get; set; }
        bool AllColumns { get; set; }
        bool UseColumnAddress { get; }
        bool UseColumnHeader { get; }
        bool UseNthColumn { get; }
    }
}